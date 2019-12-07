using System;

namespace ATM
{
     class Card
    {
        private string pin;

        public string PIN
        {
            get { return pin; }
            set
            {
                if (value.Length != 4)
                {
                    throw new Exception();
                }
                pin = value;
            }
        }

        private string pan;

        public string PAN
        {
            get { return pan; }
            set
            {
                if (value.Length != 16)
                {
                    throw new Exception();
                }
                pan = value;
            }
        }

        private string cvc;

        public string CVC
        {
            get { return cvc; }
            set
            {
                if (value.Length != 3)
                {
                    throw new Exception();
                }
                cvc = value;
            }
        }

        public string ExpireDate { get; set; }

        public decimal Balance { get; set; }
    }
}