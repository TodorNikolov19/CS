using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketStore_Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            BronzeCard BC = new BronzeCard("Ivan", 0);
            BC.calculateDiscount(150);
    
            SilverCard SC = new SilverCard("Ivan", 600);
            SC.calculateDiscount(850);

            GoldCard GC = new GoldCard("Ivan", 1500);
            GC.calculateDiscount(1300);
            */
            BronzeCard BC = new BronzeCard();
            SilverCard SC = new SilverCard();
            GoldCard GC = new GoldCard();
            try
            {
                BC.Name_owner = "Ivan";
                BC.TurnoverPreviousMonth = 0;
                BC.CalculateDiscount(150);

                SC.Name_owner="Georgi";
                SC.TurnoverPreviousMonth = 600;
                SC.CalculateDiscount(850);

                GC.Name_owner = "Victor";
                GC.TurnoverPreviousMonth=1500;
                GC.CalculateDiscount(1300);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception {0} thrown.", e.GetType().FullName);
                Console.WriteLine("Message:\n\"{0}\"", e.Message);
            }
            Console.ReadKey();
        }//Main
    }//Program

    public interface IDiscountCard
    {
        void CalculateDiscount(double valueOfPurchase);
    }

    
    public class BronzeCard : IDiscountCard
    {
        private string name_owner;
        private double turnoverPreviousMonth;
        private double discountRate;
       
        public BronzeCard(string name_owner, double turnoverPreviousMonth)
        {
            Name_owner = name_owner;
            TurnoverPreviousMonth = turnoverPreviousMonth;
        }

        public BronzeCard() { }

        public string Name_owner
        {
            get { return name_owner; }
            set
            {
                if (value == null) { throw new ArgumentNullException("ArgumentNullException..."); }
                else { name_owner = value; }
            }
        }

        public double TurnoverPreviousMonth
        {
            get { return turnoverPreviousMonth; }
            set { turnoverPreviousMonth = value; }
        }

        public double DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }



        public void CalculateDiscount(double valueOfPurchase)
        {
            Console.WriteLine("BronzeCard calculation...");
            if (TurnoverPreviousMonth < 100)
            {
                DiscountRate = 0;
            }
            else if (TurnoverPreviousMonth >= 100 && TurnoverPreviousMonth <= 300)
            {
                DiscountRate = 1;
            }
            else { DiscountRate = 2.5; }

            try
            {
                double Discount = ((valueOfPurchase * discountRate) / 100);//Discount = Math.Round(Discount, 2);
                double Total = valueOfPurchase - Discount;
                 
                Console.WriteLine("Purchase value: ${0:0.00}", valueOfPurchase);
                Console.WriteLine("Discount rate: {0:0.00}", discountRate + "%");
                Console.WriteLine("Discount: ${0:0.00}", Discount);
                Console.WriteLine("Total: ${0:0.00}", Total);
                Console.WriteLine();
                 
            }//try
            catch (ArithmeticException e)   {
                Console.WriteLine($"ArithmeticException Handler: {e}");
            }
            catch (Exception e)   {
                Console.WriteLine($"Generic Exception Handler: {e}");
            }

        }
    
    }



    public class SilverCard : IDiscountCard
    {
        private string name_owner;
        private double turnoverPreviousMonth;
        private double discountRate;

        public SilverCard(string name_owner, double turnoverPreviousMonth)
        {
            Name_owner = name_owner;
            TurnoverPreviousMonth = turnoverPreviousMonth;
        }

        public SilverCard() { }

        public string Name_owner
        {
            get { return name_owner; }
            set
            {
                if (value == null) { throw new ArgumentNullException("ArgumentNullException..."); }
                else { name_owner = value; }
            }
        }

        public double TurnoverPreviousMonth
        {
            get { return turnoverPreviousMonth; }
            set { turnoverPreviousMonth = value; }
        }

        public double DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }


        //override
        public void CalculateDiscount(double valueOfPurchase)
        {
            Console.WriteLine("SilverCard calculation...");

            if (TurnoverPreviousMonth <= 300)
            {
                DiscountRate = 2;
            }
            else if (TurnoverPreviousMonth > 300)
            {
                DiscountRate = 3.5;
            }
            try
            {
                double Discount = ((valueOfPurchase * discountRate) / 100);
                double Total = valueOfPurchase - Discount;
                 
                Console.WriteLine("Purchase value: ${0:0.00}", valueOfPurchase);
                Console.WriteLine("Discount rate: {0:0.00}", discountRate + "%");
                Console.WriteLine("Discount: ${0:0.00}", Discount);
                Console.WriteLine("Total: ${0:0.00}", Total);
                Console.WriteLine();
            }
            catch (ArithmeticException e){
                Console.WriteLine($"ArithmeticException Handler: {e}");
            }
            catch (Exception e) {
                Console.WriteLine($"Generic Exception Handler: {e}");
            }

        }

    }
    


    public class GoldCard : IDiscountCard
    {
        private string name_owner;
        private double turnoverPreviousMonth;
        private double discountRate;

        public GoldCard(string name_owner, double turnoverPreviousMonth)
        {
            Name_owner = name_owner;
            TurnoverPreviousMonth = turnoverPreviousMonth;
        }

        public GoldCard() { }

        public string Name_owner
        {
            get { return name_owner; }
            set
            {
                if (value == null) { throw new ArgumentNullException("ArgumentNullException..."); }
                else { name_owner = value; }
            }
        }

        public double TurnoverPreviousMonth
        {
            get { return turnoverPreviousMonth; }
            set { turnoverPreviousMonth = value; }
        }

        public double DiscountRate
        {
            get { return discountRate; }
            set { discountRate = value; }
        }

        //override
        public void CalculateDiscount(double valueOfPurchase)
        {
            Console.WriteLine("GoldCard calculation...");
            try
            {
                if (TurnoverPreviousMonth < 100)
                {
                    DiscountRate = 2;
                }
                else if (TurnoverPreviousMonth >= 100) 
                {
                    DiscountRate = 2 + (Math.Floor((TurnoverPreviousMonth) / 100));//return round down number int
                    if (DiscountRate > 10)
                    {
                        DiscountRate = 10;
                    }
                }

                double Discount = ((valueOfPurchase * discountRate) / 100);
                double Total = valueOfPurchase - Discount;

                Console.WriteLine("Purchase value: ${0:0.00}", valueOfPurchase);
                Console.WriteLine("Discount rate: {0:0.00}", discountRate + "%");
                Console.WriteLine("Discount: ${0:0.00}", Discount);
                Console.WriteLine("Total: ${0:0.00}", Total);
                Console.WriteLine();
            }//try
            catch (ArithmeticException e){
                Console.WriteLine($"ArithmeticException Handler: {e}");
            }
            catch (Exception e){
                Console.WriteLine($"Generic Exception Handler: {e}");
            }
             
        }

    }
}