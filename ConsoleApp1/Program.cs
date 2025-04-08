namespace ConsoleApp1
{
    public class Reservation
    {
        public string nev;
        public DateOnly kezddat;
        public DateOnly vegdat;
        public Fizess fizess;
        public int szsz;

        public Reservation (string nev, string kezddat, string vegdat, string fizess, string szsz)
        {
            this.nev = nev;
            this.kezddat = DateOnly.Parse(kezddat);
            this.vegdat = DateOnly.Parse(vegdat);
            if (Convert.ToInt32(fizess) == 0) this.fizess = Fizess.kartya;
            else this.fizess = Fizess.keszpenz;
            this.szsz = Convert.ToInt32(szsz);
        }

        public override string ToString()
        {
            return $"{nev}, {kezddat}, {vegdat}, {fizess}, {szsz}";
        }
    }

    enum Fizess
    {
        kartya = 0,
        keszpenz = 1
    }
    
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, Wordl!");

            List<Reservation> reservationlist = new List<Reservation>();
            
            using (StreamReader olvaso = new StreamReader("../../../adatok.txt"))
            {
                while (!olvaso.EndOfStream)
                {
                    string sor = olvaso.ReadLine();
                    string[] elemek = sor.Split(";");

                    reservationlist.Add(new Reservation(elemek[0], elemek[1], elemek[2], elemek[3], elemek[4]));
                }
            }

            /*foreach (Reservation reservation in reservationlist)
            {
                Console.WriteLine(reservation);
            }*/

            var firstlinq = reservationlist.Where(r => r.fizess == Fizess.keszpenz && r.szsz > 0).ToList();
            firstlinq = firstlinq.OrderBy(r => r.nev).ToList();

            foreach (Reservation f in firstlinq)
            {
                Console.WriteLine(f);
            }
        }
    }
}
