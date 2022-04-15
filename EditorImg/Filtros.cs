using AForge.Imaging.Filters;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using AForge;
using AForge.Math.Random;

namespace EditorImg
{


    //Clase de los filtros
    class Filtros
    {
        //Metodos / Filtros
        public System.Drawing.Bitmap WaterWave(string dire)
        {
            //Variable para guardar imagen dentro de un try
            try
            {
                var image = (Bitmap)Bitmap.FromFile(@"" + dire);

                //Filtro de agua
                //Modificador de filtros
                //Se crea un objeto de la clase AForge Imaging Filters
                WaterWave filter = new AForge.Imaging.Filters.WaterWave();
                filter.HorizontalWavesCount = 3;
                filter.HorizontalWavesAmplitude = 15;
                filter.VerticalWavesCount = 3;
                filter.VerticalWavesAmplitude = 15;

                //Se retorna un dato tipo Bitmap para aplicar el filtro
                return filter.Apply(image);

            }
            catch { return null; }
        }

        public System.Drawing.Bitmap AdaptiveSmoothing(string dire)
        {
            //Variable para guardar imagen dentro de un try
            try
            {
                var image = (Bitmap)Bitmap.FromFile(@"" + dire);

                //Modificador de filtro
                AdaptiveSmoothing filter = new AdaptiveSmoothing();

                //Se retorna un dato tipo Bitmap para aplicar el filtro
                return filter.Apply(image);
            }
            catch { return null; }

        }

        public System.Drawing.Bitmap AdditiveNoise(string dire)
        {
            //Variable para guardar imagen dentro de un try
            try
            {
                var image = (Bitmap)Bitmap.FromFile(@"" + dire);

                //Modificador de filtros
                IRandomNumberGenerator generator = new UniformGenerator(new Range(-50, 50));
                AdditiveNoise filter = new AdditiveNoise(generator);
                //Se retorna un dato tipo Bitmap para aplicar el filtro
                return filter.Apply(image);

            }
            catch { return null; }

        }

        public System.Drawing.Bitmap SaturationCorrection(string dire)
        {
            //Variable para guardar imagen dentro de un try
            try
            {
                var image = (Bitmap)Bitmap.FromFile(@"" + dire);

                //Modificador de filtros
                SaturationCorrection filter = new SaturationCorrection(-0.5f);
                return filter.Apply(image);

            }
            catch { return null; }

        }

        public System.Drawing.Bitmap SimplePosterization(string dire)
        {
            //Variable para guardar imagen dentro de un try
            try
            {
                var image = (Bitmap)Bitmap.FromFile(@"" + dire);

                //Modificador de filtros
                // create filter
                SimplePosterization filter = new SimplePosterization();
                // process image
                return filter.Apply(image);

            }
            catch { return null; }

        }



        
    }
}


