using MyCodeKatas;
using MyCodeKatas.Model;

namespace Model.MyCodeKatas
{
    public class Kata : ModelBase
    {
        public string Name { get; set; }
        public WorkingState WorkingState { get; set; }
        public string Note { get; set; }
        public override string ToString()
        {
            return this.Name;
        }
    }
}