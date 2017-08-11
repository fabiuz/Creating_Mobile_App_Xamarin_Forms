using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Greetings
{
    public class BmpMaker
    {
        const int headerSize = 54;
        readonly byte[] buffer;

        public BmpMaker(int width, int height)
        {
            Width = width;
            Height = height;

            int numPixels = Width * Height;
            int numPixelBytes = 4 * numPixels;
            int fileSize = headerSize + numPixelBytes;
            buffer = new byte[fileSize];

            // Grava os cabeçalhos em MemoryStream e define o buffer.
            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (BinaryWriter writer = new BinaryWriter(memoryStream, Encoding.UTF8))
                {
                    // Constrói o cabeçalho do BMP (14 bytes).
                    writer.Write(new char[] { 'B', 'M' });      // Assinatura.
                    writer.Write(fileSize);                     // Tamanho do arquivo.
                    writer.Write((short)0);                     // Reservado.
                    writer.Write((short)0);                     // Reservado.
                    writer.Write(headerSize);                   // Deslocamento para o pixels.

                    // Constrói o BitmapInfoHeader(40 bytes).
                    writer.Write(40);                           // Tamanho do cabeçalho.
                    writer.Write(Width);                        // Largura do pixel.
                    writer.Write(Height);                       // Altura do pixel.
                    writer.Write((short)1);                     // Planos.
                    writer.Write((short)32);                    // Bits por pixel.
                    writer.Write(0);                            // Compressão.
                    writer.Write(numPixelBytes);                // Tamanho da imagem em bytes.
                    writer.Write(0);                            // Pixels X por metro.
                    writer.Write(0);                            // Pixels Y por metro.
                    writer.Write(0);                            // Número de cores na tabela de cor.
                    writer.Write(0);                            // Contagem de cores importantes.
                }
            }
        }

        public int Width
        {
            private set; get;
        }

        public int Height
        {
            private set; get;
        }

        public void SetPixel(int row, int col, Color color)
        {
            SetPixel(row, col, (int)(255 * color.R),
                                (int)(255 * color.G),
                                (int)(255 * color.B),
                                (int)(255 * color.A));
        }

        public void SetPixel(int row, int col, int r, int g, int b, int a = 255)
        {
            int index = (row * Width + col) * 4 + headerSize;
            buffer[index + 0] = (byte)b;
            buffer[index + 1] = (byte)g;
            buffer[index + 2] = (byte)r;
            buffer[index + 3] = (byte)a;
        }

        public ImageSource Generate()
        {
            // Cria MemoryStream de um buffer com bitmap.
            MemoryStream memoryStream = new MemoryStream(buffer);

            // Converte para StreaImageSource.
            ImageSource imageSource = ImageSource.FromStream(
                () => 
                {
                    return memoryStream;
                });
            return imageSource;
        }
    }
}
