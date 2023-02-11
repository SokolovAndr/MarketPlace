namespace VkusProekt.Data.Models
{
    public class Bludo
    {
        public int id { get; set; }
        public string name { get; set; }
        public string shortDesc { get; set; } //краткое описание
        public string longDesc { get; set; } //полное описание
        public string img { get; set; }  // url - адрес картинки
        public ushort price { get; set; }  //ushort потому что цена не может быть со знаком минус//
        public bool isFavourite { get; set; }  // отображается на главной странице или нет//
        public bool available { get; set; } // кол-во товара//
        public int categoryID { get; set; }
        public virtual Category Category { get; set; } //у одного товара может быть только 1 категория ///
    }
}
