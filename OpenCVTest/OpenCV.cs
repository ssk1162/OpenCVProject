using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Windows.Documents;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OpenCVTest
{
    internal class OpenCV
    {
        private Mat gray;
        private Mat binary;
        private Mat canny;
        private Mat corner;
        private Mat apcon;
        private Mat bin;
        private Mat affine;
        private Mat morp;

        CoordinatesXY xy = new CoordinatesXY();

        private int XYCount = 0;

        // 영상이나 이미지의 색상을 흑백 색상으로 변환하기 위해 사용
        public Mat GrayScale(Mat src)
        {
            gray = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            return gray;
        }

        // 이진화
        // 영상이나 이미지를 어느 지점을 기준으로 흑색 또는 흰색의 색상으로 변환하기 위해 사용
        // 0 흑색, 255 백색
        public Mat BinaryA(Mat src)
        {
            gray = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            int pixel = Cv2.GetTrackbarPos("임계치", "Binary");
            binary = new Mat(src.Size(), MatType.CV_8UC1, new Scalar(pixel, pixel, pixel));
            Cv2.Threshold(gray, binary, pixel, 255, ThresholdTypes.Binary);

            return binary;
        }

        // 영상이나 이미지의 가장자리를 검출하기 위해 사용
        public Mat CannyEdge(Mat src)
        {
            int pixel = Cv2.GetTrackbarPos("임계치", "Canny");
            canny = new Mat(src.Size(), MatType.CV_8UC1, new Scalar(pixel, pixel, pixel));
            Cv2.Canny(src, canny, pixel, 255);

            return canny;
        }

        // 영상이나 이미지의 모서리(코너)를 검출하기 위해 사용
        public Mat GoodFeaturesToTrack(Mat src)
        {
            corner = new Mat(src.Size(), MatType.CV_8UC3);
            gray = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CopyTo(src, corner);
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);

            // 입력 이미지, 코너의 최대 개수, 코너의 조건 (0.01 * 1000 = 퀄리티 레벨 * 강도) 10보다 이상일때 코너로 간주, 최소거리
            // 코너가 감지되는 영역, 코너 계산을 위한 평균 블록의 크기, Harris 방법을 사용할지에 대한 bool값, Harris 방법의 매개 변수
            Point2f[] corners = Cv2.GoodFeaturesToTrack(gray, 130, 0.01, 5, null, 3, true, 0.01);

            // 입력 이미지, 처음 검출된 코너, 윈도우의 크기, 제외할 영역 크기, 코너 정밀화 작업(최대 10번 반복하고 정확도 0.03보다 작으면 종료)
            //Point2f[] sub_corner = Cv2.CornerSubPix(gray, corners, new Size(3, 3), new Size(-1, -1), TermCriteria.Both(10, 0.03));

            for (int i = 0; i < corners.Length; i++)
            {
                Point pt = new Point(corners[i].X, corners[i].Y);
                // 이미지, point xy좌표, 반지름, 색, 원의 두께(숫자로 입력시 테두리가 노란색인 원이 생성, FILLED 노란색원 생성)
                Cv2.Circle(corner, pt, 5, Scalar.Yellow, Cv2.FILLED);
            }

            //for (int i = 0; i < sub_corner.Length; i++)
            //{
            //    Point pt = new Point(sub_corner[i].X, sub_corner[i].Y);
            //    Cv2.Circle(corner, pt, 5, Scalar.Red, Cv2.FILLED);
            //}

            return corner;
        }

        // ApproxPoly를 사용하기 위해 만든거
        public Mat BinaryB(Mat src)
        {
            bin = new Mat(src.Size(), MatType.CV_8UC1);
            gray = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, bin, 190, 255, ThresholdTypes.Binary);
            return bin;
        }

        public Mat ApproxPoly(Mat src)
        {
            apcon = new Mat(src.Size(), MatType.CV_8UC3);
            binary = new Mat(src.Size(), MatType.CV_8UC1);

            Cv2.CopyTo(src, apcon);
            binary = this.BinaryB(src);

            // 이미지 처리에서 윤곽선을 찾고 계층 구조를 저장
            Point[][] contours;
            // 계층 구조를 저장하는 배열
            HierarchyIndex[] hierarchy;

            // 이미지, 검출된 윤곽선, 계층 구조, 검색방법, 근사 방법
            Cv2.FindContours(binary, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxNone);

            for (int i = 0; i < contours.Length; i++)
            {
                // 윤곽선을 근사화하여 다각형으로 변환
                // 입력된 윤곽선, 근사화 정확도, 폐곡선 여부
                Point[] approx = Cv2.ApproxPolyDP(contours[i], 3, false);

                // 점이 4개 이상일때 그림
                if (approx.Length > 3)
                {
                    foreach (Point pt in approx)
                    {
                        Cv2.Circle(apcon, pt, 5, Scalar.Black, Cv2.FILLED);
                        Console.WriteLine(pt);
                    }
                }

            }

            return apcon;
        }

        public Mat GeometricImage(Mat src)
        {
            affine = new Mat(src.Size(), MatType.CV_8UC3);

            bin = this.BinaryB(src);

            float width = src.Size().Width;
            float height = src.Size().Height;

            // 4개의 점을 받기
            Point2f[] srcPoint = new Point2f[4];
            Point2f[] dstPoint = new Point2f[4];

            srcPoint[0] = new Point2f(xy.LUpX, xy.LUpY);
            srcPoint[1] = new Point2f(xy.LDownX, xy.LDownY);
            srcPoint[2] = new Point2f(xy.RUpX, xy.RUpY);
            srcPoint[3] = new Point2f(xy.RDownX, xy.RDownY);

            dstPoint[0] = new Point2f(0.0f, 0.0f);
            dstPoint[1] = new Point2f(0.0f, height);
            dstPoint[2] = new Point2f(width, 0.0f);
            dstPoint[3] = new Point2f(width, height);

            Mat matrix = Cv2.GetPerspectiveTransform(srcPoint, dstPoint);

            Cv2.WarpPerspective(bin, affine, matrix, src.Size(), InterpolationFlags.Linear, BorderTypes.Default, Scalar.All(0));

            return affine;
        }

        public void MouseXY(float x, float y)
        {
            XYCount++;
            if (XYCount == 1)
            {
                xy.LUpX = x;
                xy.LUpY = y;
            }
            else if (XYCount == 2)
            {
                xy.LDownX = x;
                xy.LDownY = y;
            }
            else if (XYCount == 3)
            {
                xy.RUpX = x;
                xy.RUpY = y;
            }
            else
            {
                xy.RDownX = x;
                xy.RDownY = y;
            }

            if (XYCount >= 4)
            {
                XYCount = 0;
            }
        }

        // 모폴로지 사용용
        public Mat BinaryC(Mat src, int threshold)
        {
            bin = new Mat(src.Size(), MatType.CV_8UC1);
            gray = new Mat(src.Size(), MatType.CV_8UC1);
            Cv2.CvtColor(src, gray, ColorConversionCodes.BGR2GRAY);
            Cv2.Threshold(gray, bin, threshold, 255, ThresholdTypes.Binary);
            return bin;
        }

        // 팽창
        // 영역 내의 현재 픽셀을 최대 픽셀값으로 대체
        // 최대 픽셀 값(255) = 밝은 영역
        public Mat DilateImage(Mat src)
        {
            int pixel = Cv2.GetTrackbarPos("임계치", "Dilate");
            morp = new Mat(src.Size(), MatType.CV_8UC1, new Scalar(pixel, pixel, pixel));
            bin = this.BinaryC(src, pixel);
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.Dilate(bin, morp, kernel, new Point(-1, -1), 3);
            return morp;
        }

        // 침식
        // 최소 픽셀값으로 대체
        // 최소 픽셀 값(0) = 어두운 영역
        // 노이즈를 제거하거나 노이즈 제거 후 크기를 복구하기 위해 사용
        // 팽창후 침식 / 침식 후 팽창으로 사용
        public Mat ErodeImage(Mat src)
        {
            int pixel = Cv2.GetTrackbarPos("임계치", "Erode");
            morp = new Mat(src.Size(), MatType.CV_8UC1, new Scalar(pixel, pixel, pixel));
            bin = this.BinaryC(src, pixel);
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.Erode(bin, morp, kernel, new Point(-1, -1), 3);
            return morp;
        }

        //모폴로지 연산
        //열기, 닫기, 그라디언트, 탑햇, 블랙햇 연산, 히토미스
        public Mat OpenMorphology(Mat src)
        {
            // 열기 연산
            // 팽창 > 침식 연산자 조합
            morp = new Mat(src.Size(), MatType.CV_8UC1);
            bin = this.BinaryC(src, 100);

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.MorphologyEx(bin, morp, MorphTypes.Open, kernel, iterations: 3);

            return morp;

        }

        public Mat CloseMorphology(Mat src)
        {
            // 열기 연산
            // 침식 > 팽창 연산자 조합
            morp = new Mat(src.Size(), MatType.CV_8UC1);
            bin = this.BinaryC(src, 100);

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.MorphologyEx(bin, morp, MorphTypes.Close, kernel, iterations: 3);

            return morp;

        }

        public Mat GradientMorphology(Mat src)
        {
            morp = new Mat(src.Size(), MatType.CV_8UC1);
            bin = this.BinaryC(src, 50);

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.MorphologyEx(bin, morp, MorphTypes.Gradient, kernel, iterations: 3);

            return morp;

        }

        public Mat TopHatMorphology(Mat src)
        {
            morp = new Mat(src.Size(), MatType.CV_8UC1);
            bin = this.BinaryC(src, 50);

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.MorphologyEx(bin, morp, MorphTypes.TopHat, kernel, iterations: 3);

            return morp;

        }
        public Mat BlackHatMorphology(Mat src)
        {
            morp = new Mat(src.Size(), MatType.CV_8UC1);
            bin = this.BinaryC(src, 50);

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.MorphologyEx(bin, morp, MorphTypes.BlackHat, kernel, iterations: 3);

            return morp;

        }

        // 이진화 처리된 이미지에 커널의 형태를 남겨 모서리(코너)를 검출할 때 사용
        public Mat HitMissMorphology(Mat src)
        {
            morp = new Mat(src.Size(), MatType.CV_8UC1);
            bin = this.BinaryC(src, 50);

            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Rect, new Size(5, 5));
            Cv2.MorphologyEx(bin, morp, MorphTypes.HitMiss, kernel, iterations: 3);

            return morp;
        }

        private string colorStr;
        private string maxColor;
        private string biggestColor;
        private Mat circle;

        private readonly Random random = new Random();
        private readonly int[] colorCounts = new int[9];
        private enum colorNames
        {
            Red,
            Orange,
            Yellow,
            Green,
            Blue,
            Cyan,
            Pink,
            Magenta,
            White
        }

            
        public Scalar GetColorScalar(string colorName)
        {
            // Vec3b = 3개의 byte를 가진 벡터이고, 이미지 색상 정보를 표현하는데 사용
            // Item0 = Blue
            // Item1 = Green
            // Item2 = Red
            Vec3b hsvColor;

            switch (colorName)
            {
                case "Red":
                    // B = 0, G = 255, R = 255
                    hsvColor = new Vec3b(0, 255, 255);
                    break;
                case "Orange":
                    hsvColor = new Vec3b(15, 255, 255);
                    break;
                case "Yellow":
                    hsvColor = new Vec3b(30, 255, 255);
                    break;
                case "Green":
                    hsvColor = new Vec3b(60, 255, 255);
                    break;
                case "Blue":
                    hsvColor = new Vec3b(120, 255, 255);
                    break;
                case "Cyan":
                    hsvColor = new Vec3b(90, 255, 255);
                    break;
                case "Pink":
                    hsvColor = new Vec3b(150, 128, 255);
                    break;
                case "Magenta":
                    hsvColor = new Vec3b(150, 200, 255);
                    break;
                case "White":
                    return new Scalar(255, 255, 255);
                default:
                    return new Scalar(0, 0, 0);
            }

            // HSV -> BGR로 변환
            Mat hsv = new Mat(1, 1, MatType.CV_8UC3, new Scalar(hsvColor.Item0, hsvColor.Item1, hsvColor.Item2));
            Mat bgr = new Mat();
            Cv2.CvtColor(hsv, bgr, ColorConversionCodes.HSV2BGR);

            // 좌표 위치에 픽셀값을 Vec3b 타입으로 반환
            // BGR로 변환된 BGR 색상 값을 읽어온다
            Vec3b bgrColor = bgr.At<Vec3b>(0, 0);

            // Scalar 객체로 반환
            return new Scalar(bgrColor.Item0, bgrColor.Item1, bgrColor.Item2);
        }

        public void AnalyzeColor(Mat src)
        {
            Mat hsvImage = new Mat();
            // 이미지를 HSV로 변환 하여 hsvImage에 저장
            Cv2.CvtColor(src, hsvImage, ColorConversionCodes.BGR2HSV);

            // 색상 카운트 배열을 0으로 초기화
            Array.Clear(colorCounts, 0, colorCounts.Length);

            // 무작위로 100개의 픽셀을 선택하여 색상 분석
            for (int i = 0; i < 100; i++)
            {
                // 랜덤으로 x, y 좌표를 선택
                int wNum = random.Next(hsvImage.Cols);
                int hNum = random.Next(hsvImage.Rows);
                Vec3b hsvColor = hsvImage.At<Vec3b>(hNum, wNum);

                // HSV 값
                byte hue = hsvColor.Item0;
                byte saturation = hsvColor.Item1;
                byte value = hsvColor.Item2;

                // 채도, 명도
                if (saturation < 10 && value > 200)
                {
                    colorCounts[(int)colorNames.White]++;
                }
                else
                {
                    // 색상 카운트
                    if ((hue >= 0 && hue <= 10) || (hue >= 170 && hue <= 180)) // Red
                        colorCounts[(int)colorNames.Red]++;
                    else if (hue >= 11 && hue <= 25) // Orange
                        colorCounts[(int)colorNames.Orange]++;
                    else if (hue >= 26 && hue <= 40) // Yellow
                        colorCounts[(int)colorNames.Yellow]++;
                    else if (hue >= 41 && hue <= 84) // Green
                        colorCounts[(int)colorNames.Green]++;
                    else if (hue >= 85 && hue <= 100) // Blue
                        colorCounts[(int)colorNames.Blue]++;
                    else if (hue >= 101 && hue <= 140) // Cyan
                        colorCounts[(int)colorNames.Cyan]++;
                    else if (hue >= 141 && hue <= 165) // Pink
                        colorCounts[(int)colorNames.Pink]++;
                    else if (hue >= 166 && hue <= 179) // Magenta
                        colorCounts[(int)colorNames.Magenta]++;
                }
            }

            // 가장 많이 나타난 색상의 수를 찾기
            int maxIndex = Array.IndexOf(colorCounts, colorCounts.Max());
            // enum에서 인덱스를 사용 색상을 찾는다
            maxColor = Enum.GetName(typeof(colorNames), maxIndex);
            biggestColor = $"{maxColor} : {colorCounts[maxIndex]}%";

            colorStr = string.Join("\n\r", Enum.GetValues(typeof(colorNames)).Cast<colorNames>()
                .Select(color => colorCounts[(int)color] > 0 ? $"{color} : {colorCounts[(int)color]}%" : ""));
        }

        public Mat AllCircleColor(Mat src)
        {
            Mat dst = src.Clone();
            circle = new Mat();

            if (src.Channels() != 1)
                Cv2.CvtColor(src, circle, ColorConversionCodes.BGR2GRAY);
            else
                src.CopyTo(circle);

            Cv2.GaussianBlur(circle, circle, new Size(13, 13), 3, 3);

            CircleSegment[] circles = Cv2.HoughCircles(circle, HoughModes.Gradient, 1, 100, 100, 35, 0, 0);
            foreach (var circleSegment in circles)
            {
                Point center = (Point)circleSegment.Center;
                double radius = circleSegment.Radius;

                Rect areaRect = new Rect(
                    (int)(center.X - radius),
                    (int)(center.Y - radius),
                    (int)(2 * radius),
                    (int)(2 * radius)
                );

                using (Mat area = new Mat(src, areaRect))
                {
                    AnalyzeColor(area);
                }

                // 텍스트 위치 조정
                string text = biggestColor;
                Size textSize = Cv2.GetTextSize(text, HersheyFonts.HersheySimplex, 0.7, 1, out int baseline);

                // 텍스트를 원의 중심 위쪽으로 위치 조정
                Point textOrigin = new Point(center.X - textSize.Width / 2, center.Y - (int)(radius + textSize.Height + baseline));

                Cv2.PutText(dst, text, textOrigin, HersheyFonts.HersheySimplex, 0.7, GetColorScalar(maxColor), 1);

            }

            return dst;
        }


    }
}
