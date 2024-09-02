using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenCVTest
{
    internal class OpenCVBlur
    {
        private Mat blur;
        private Mat box_filter;
        private Mat median_blur;
        private Mat gaussian_blur;
        private Mat bilateral_filter;

        // 모든 픽셀의 단순 평균을 구한다
        public Mat btnBlur(Mat src)
        {
            blur = new Mat();
            // 원본, 결과, 커널사이즈, 고정점, 테두리 외삽법
            Cv2.Blur(src, blur, new Size(9, 9), new Point(-1, -1), BorderTypes.Default);

            return blur;
        }

        // 커널의 내부값이 모두 값은 값으로 구한다
        public Mat btnBoxFilter(Mat src)
        {
            box_filter = new Mat();
            // 원본, 결과, 정밀도, 커널사이즈, 고정점, 테두리 외삽법
            Cv2.BoxFilter(src, box_filter, MatType.CV_8UC3, new Size(9, 9), new Point(-1, -1), true, BorderTypes.Default);

            return box_filter;
        }

        // 고정점을 사용하지 않고 중심 픽셀 주변으로 사각형 크기의 이웃한 픽셀드르이 중간값을 사용해 각 픽셀의 값을 변경
        public Mat btnMedianBlur(Mat src)
        {
            median_blur = new Mat();
            // 커널 크기는 홀수만 가능
            Cv2.MedianBlur(src, median_blur, 9);
            
            return median_blur;
        }

        // 이미지의 각 지점에 가우시안 커널을 적용해 합산한 후 출력 이미지 반환
        public Mat btnGaussianBlur(Mat src)
        {
            gaussian_blur = new Mat();
            // 원본, 결과, 커널, xy편차값, 테두리 외삽법
            // 편차값이 0이면 커널 크기를 고려해 자동 설정
            Cv2.GaussianBlur(src, gaussian_blur, new Size(9, 9), 3, 3, BorderTypes.Default);

            return gaussian_blur;
        }

        public Mat btnBilateralFilter(Mat src)
        {
            bilateral_filter = new Mat();
            // 원본, 결과, 지름, 시그마 색상, 시그마 공간, 테두리 외삽법
            // 시그마 색상 : 가우시안 커널의 너비를 설정, 매개변수의 값이 클수록 흐림 효과에 포함될 강도의 범위가 넓어진다
            // 시그마 공간 : 값이 클수록 인접한 픽셀에 영향을 미침
            try
            {
                Cv2.BilateralFilter(src, bilateral_filter, 9, 3, 3, BorderTypes.Default);
            }
            catch (OpenCVException ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return bilateral_filter;
        }

    }
}
