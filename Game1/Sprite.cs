using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Game1
{
    class Sprite
    {
        private Vector2 pos;
        private Vector2 scale;
        private Texture2D texture;

        public float Rot { get; set; }
        public float RotSpeed { get; set; }
        public float X { get => pos.X; set => pos.X = value; }
        public float Y { get => pos.Y; set => pos.Y = value; }
        public Vector2 Pos { get => pos; set => pos = value; }
        public Vector2 Size
        {
            get => scale * texture.Bounds.Size.ToVector2();
            set => scale = value / texture.Bounds.Size.ToVector2();
        }
        public Vector2 Scale { get => scale; set => scale = value; }

        public Sprite(Texture2D texture, Vector2? pos, Vector2? scale)
        {
            this.pos = pos ?? new Vector2(0, 0);
            this.scale = scale ?? new Vector2(1, 1);
            this.texture = texture;
        }
        public void Update(GameTime gameTime)
        {
            Rot += RotSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(
                texture: texture,
                position: pos,
                scale: scale,
                color: Color.White,
                rotation: Rot,
                origin: texture.Bounds.Size.ToVector2() / 2
            );
        }
    }
}
