using Interfaces;

namespace Logic
{
    internal class SpriteModel : ISprite
    {
        public string name { get; set; }
        public string path { get; set; }
        public int price { get; set; }
    }
}
