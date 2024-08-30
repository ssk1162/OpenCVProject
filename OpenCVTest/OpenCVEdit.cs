using OpenCvSharp;

namespace OpenCVTest
{
    internal class OpenCVEdit
    {
        Mat pyr;

        private double currentAngle;

        public Mat ribbonUpDown(Mat src, double xy)
        {
            pyr = new Mat(src.Size(), MatType.CV_8UC3);
            Cv2.Resize(src, pyr, new Size(0, 0), xy / 100.0, xy / 100.0);
            return pyr;
        }
        
        public Mat RibbonSymmetryX(Mat src)
        {
            pyr = new Mat(src.Size(), MatType.CV_8UC3);
            Cv2.Flip(src, pyr, FlipMode.X);
            return pyr;
        }

        public Mat RibbonSymmetryY(Mat src)
        {
            pyr = new Mat(src.Size(), MatType.CV_8UC3);
            Cv2.Flip(src, pyr, FlipMode.Y);
            return pyr;
        }
        
        public Mat Ribbon45Rotation(Mat src)
        {
            pyr = new Mat(src.Size(), MatType.CV_8UC3);

            currentAngle += 45.0;
            // 중심점, 각도, 스케일
            // 2 X 3 회전 행렬 생성 함수 = GetRotationMatrix2D / Mat 형식의 회전 행렬을 생성
            // 중심점의 좌표로 90도 회전만큼 1비율 크기로 변경
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(src.Width / 2, src.Height / 2), currentAngle, 1);

            // 아핀 변환 함수 = 회전 행렬을 사용해 회전된 이미지를 생성
            Cv2.WarpAffine(src, pyr, matrix, new Size(src.Width, src.Height));
            return pyr;
        }
        
        public Mat Ribbon90Rotation(Mat src)
        {
            pyr = new Mat(src.Size(), MatType.CV_8UC3);

            currentAngle += 90.0;
            // 중심점, 각도, 스케일
            // 2 X 3 회전 행렬 생성 함수 = GetRotationMatrix2D / Mat 형식의 회전 행렬을 생성
            // 중심점의 좌표로 90도 회전만큼 1비율 크기로 변경
            Mat matrix = Cv2.GetRotationMatrix2D(new Point2f(src.Width / 2, src.Height / 2), currentAngle, 1);

            // 아핀 변환 함수 = 회전 행렬을 사용해 회전된 이미지를 생성
            Cv2.WarpAffine(src, pyr, matrix, new Size(src.Width, src.Height));
            return pyr;
        }
    }
}
