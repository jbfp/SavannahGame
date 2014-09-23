using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SavannahGame.Forms
{
    public class GraphicsVisitor : IAnimalVisitor, ISavannahVisitor
    {
        private readonly Graphics graphics;
        private readonly IDictionary<string, Image> textures;
        private readonly Size size;

        public GraphicsVisitor(Graphics graphics, IDictionary<string, Image> textures, Size size)
        {
            if (graphics == null)
            {
                throw new ArgumentNullException("graphics");
            }

            if (textures == null)
            {
                throw new ArgumentNullException("textures");
            }

            this.graphics = graphics;
            this.graphics.InterpolationMode = InterpolationMode.NearestNeighbor;
            this.graphics.SmoothingMode = SmoothingMode.HighQuality;
            this.textures = textures;
            this.size = size;
        }

        public void Visit(Lion lion)
        {
            Visit<Lion>(lion);
        }

        public void Visit(Rabbit rabbit)
        {
            Visit<Rabbit>(rabbit);
        }

        public void Visit(Grass grass)
        {
            Image texture;
            var point = new Point(grass.X * this.size.Width, grass.Y * this.size.Height);
            var rectangle = new Rectangle(point, this.size);
            
            if (this.textures.TryGetValue("Sand", out texture))
            {
                this.graphics.DrawImage(texture, rectangle);
            }

            if (grass.IsAlive)
            {
                if (this.textures.TryGetValue("Grass", out texture))
                {
                    this.graphics.DrawImage(texture, rectangle);
                }
            }
        }

        private void Visit<T>(T animal) where T : Animal
        {
            Image texture;

            if (this.textures.TryGetValue(typeof (T).Name, out texture))
            {
                var point = new Point(animal.X * this.size.Width, animal.Y * this.size.Height);
                var rectangle = new Rectangle(point, this.size);
                this.graphics.DrawImage(texture, rectangle);

                if (animal.IsAlive == false && this.textures.TryGetValue("Cross", out texture))
                {
                    this.graphics.DrawImage(texture, rectangle);
                }
            }
        }
    }
}