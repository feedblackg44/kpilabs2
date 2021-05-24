using System;

namespace MyClass
{
    public class MobileAccount
    {
        private string _name;
        private bool _isActive;
        private decimal _money;
        public delegate void MyEventDelegate();
        public event MyEventDelegate MyEvent = null;


        public MobileAccount(string name)
        {
            _isActive = false;
            _name = name;
            _money = 0;
        }
        public void Activate()
        {
            _isActive = true;
        }
        public decimal AddMoney(decimal amount)
        {
            if (!_isActive)
            {
                throw new Exception("Account is not active!");
            }
            if (amount > 0)
                _money += amount;
            else
                throw new Exception("Wrong amount of money!");
            return _money;
        }
        public decimal Talk(uint days)
        {
            if (!_isActive)
            {
                throw new Exception("Account is not active!");
            }
            decimal k = 20;
            _money -= k * days;
            if (_money <= 0)
            {
                _money = 0;
                if (MyEvent != null)
                {
                    MyEvent();
                }
            }
            return _money;
        }
    }
}
