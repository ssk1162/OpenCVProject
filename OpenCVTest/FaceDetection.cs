using OpenCvSharp;
using System;

namespace OpenCVTest
{
    internal class FaceDetection
    {
        public Mat haarface(Mat src, Mat osrc)
        {
            Mat face = src.Clone();

            using (CascadeClassifier cascade = new CascadeClassifier("haarcascade_frontalface_default.xml"))
            {
                double scale = 1.0;

                using (Mat det_Image = new Mat(new Size(Math.Round(src.Width / scale), Math.Round(src.Height / scale)), MatType.CV_8UC1))
                using (Mat gray = new Mat(src.Size(), MatType.CV_8UC1))
                {
                    Cv2.CvtColor(src, gray, ColorConversionCodes.BGRA2GRAY);
                    Cv2.Resize(gray, det_Image, det_Image.Size(), interpolation: InterpolationFlags.Linear);
                    Cv2.EqualizeHist(det_Image, det_Image);

                    Rect[] faces = cascade.DetectMultiScale(det_Image, 1.2, 3, flags: HaarDetectionTypes.ScaleImage, minSize: new Size(60, 60));

                    foreach (Rect rect in faces)
                    {
                        Mat resizedOverlay = new Mat();

                        Size enlargedSize = new Size((int)(rect.Width * 1.9), (int)(rect.Height * 1.9));

                        Cv2.Resize(osrc, resizedOverlay, enlargedSize);

                        int newY = rect.Y - (int)(rect.Height * 0.6);

                        Rect enlargedRect = new Rect(
                            rect.X - (enlargedSize.Width - rect.Width) / 2,
                            newY,
                            enlargedSize.Width,
                            enlargedSize.Height
                        );

                        Rect roiRect = enlargedRect & new Rect(0, 0, face.Width, face.Height);
                        var roi = new Mat(face, roiRect);

                        for (int y = 0; y < resizedOverlay.Rows; y++)
                        {
                            for (int x = 0; x < resizedOverlay.Cols; x++)
                            {
                                if (y < roi.Rows && x < roi.Cols)
                                {
                                    Vec4b overlayPixel = resizedOverlay.At<Vec4b>(y, x);
                                    Vec3b roiPixel = roi.At<Vec3b>(y, x);

                                    float alpha = overlayPixel[3] / 255.0f;

                                    for (int c = 0; c < 3; c++)
                                        roiPixel[c] = (byte)(overlayPixel[c] * alpha + roiPixel[c] * (1.0 - alpha));

                                    roi.Set(y, x, roiPixel);
                                }
                            }
                        }
                    }
                }
            }
            return face;
        }


    }
}
