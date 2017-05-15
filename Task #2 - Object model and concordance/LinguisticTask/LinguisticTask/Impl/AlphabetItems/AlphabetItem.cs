
namespace LinguisticTask.Impl.AlphabetItems
{
    struct AlphabetItem
    {
        private char _item;
        private LetterType _letterType;
        private PrescriptionType _prescriptionType;
        public char Item
        { 
            get { return _item; }
            set { _item = value; }
        }
        public LetterType LetterType 
        {
            get { return _letterType; }
            set { _letterType = value; }
        }
        public PrescriptionType PrescriptionType 
        {
            get { return _prescriptionType; }
            set { _prescriptionType = value; }
        }
        public AlphabetItem(char item, LetterType letterType, PrescriptionType prescriptionType)
        {
            _item = item;
            _letterType = letterType;
            _prescriptionType = prescriptionType;
        }
    }
}
