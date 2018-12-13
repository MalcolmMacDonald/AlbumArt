using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using System.Drawing;

namespace AlbumArt
{
    class TextDetection
    {

        public TextDetection()
        {

        }


        public List<Rectangle> GetTextRects(Bitmap currentImage)
        {
            string tessPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\tessdata";
            TesseractEngine tess = new TesseractEngine(tessPath, "eng");

            Page newPage = tess.Process(currentImage, PageSegMode.AutoOsd);

            ResultIterator iterator = newPage.GetIterator();
            string totalText = newPage.GetText();
            List<Rectangle> currentRects = new List<Rectangle>();
            for (int i = 0; i < totalText.Length; i++)
            {
                
              Rect foundRect = new Rect();
                string symbolText = iterator.GetText(PageIteratorLevel.Symbol);
                bool hasText = symbolText != "" && symbolText != null;
                bool onlyLetters = false;
                if (hasText)
                {
                    onlyLetters = symbolText.ToCharArray().All(s => char.IsLetter(s));
                }

                bool gotBoundingBox = iterator.TryGetBoundingBox(PageIteratorLevel.Symbol, out foundRect);

                if (hasText && onlyLetters && gotBoundingBox)
                {
                    currentRects.Add(new Rectangle(foundRect.X1, foundRect.Y1, foundRect.X2 - foundRect.X1, foundRect.Y2 - foundRect.Y1));
                }
                iterator.Next(PageIteratorLevel.Symbol);
            }
            tess.Dispose();
            iterator.Dispose();

            return currentRects;
        }
    }
}
