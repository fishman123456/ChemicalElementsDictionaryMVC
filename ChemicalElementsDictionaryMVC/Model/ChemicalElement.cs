namespace ChemicalElementsDictionaryMVC.Model
{
    public class ChemicalElement
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Code { get; set; }
        public double Mass { get; set; }
        public ChemicalElement() 
        {
            FullName = string.Empty;
            Code = string.Empty;

        }
        public override string ToString()
        {
            return $"{Id} - {FullName} - {Code} - {Mass}";
        }
    }
}
