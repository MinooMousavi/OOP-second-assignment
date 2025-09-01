using TextFile;
using System;
using System.Collections.Generic;
using assignment2;
namespace assignment2
{

    public abstract class Colony
    {
        protected Random rand = new Random();
        protected int turns = 0;
        public string name { get; set; }
        protected int Count { get; set; }

        public int getCount()
        {
            return Count;
        }

        public override string ToString()
        {
            return name + " " + Count;
        }

        public abstract class Prey : Colony
        {
            public abstract void Turn();
            public abstract int AttackedBy(Predators p);
        }

        public abstract class Predators : Colony
        {
            protected int startval;

            public int getstartval()
            {
                return startval;
            }
            public abstract void Attack(List<Prey> p);
        }

        public class Lemming : Prey
        {
            public Lemming(string name, int nr)
            {
                if (nr < 0) throw new ArgumentOutOfRangeException();
                this.name = name;
                this.Count = nr;

            }
            public override int AttackedBy(Predators p)
            {
                Count -= 4 * p.getCount();
                int i = Count / 4;
                if (Count < 0) Count = 0;
                return i;

            }
            public override void Turn()
            {
                turns++;
                if (turns == 2)
                {
                    Count *= 2;
                    if (Count > 200)
                    {
                        Count = 30;
                    }
                    turns = 0;
                }
            }
        }

        public class Hare : Prey
        {
            public Hare(string name, int nr)
            {
                if (nr < 0) throw new ArgumentOutOfRangeException();
                this.name = name;
                this.Count = nr;

            }
            override public int AttackedBy(Predators p)
            {
                Count -= 2 * p.getCount();
                int i = Count / 2;
                if (Count < 0)
                {
                    Count = 0;
                }
                return i;
            }
            override public void Turn()
            {
                turns++;
                if (turns == 2)
                {
                    Count = (int)(Count * 1.5);
                    if (Count > 100)
                    {
                        Count = 20;
                    }
                    turns = 0;
                }
            }
        }

        public class Gopher : Prey
        {
            public Gopher(string name, int nr)
            {
                if (nr < 0) throw new ArgumentOutOfRangeException();
                this.name = name;
                this.Count = nr;

            }
            public override int AttackedBy(Predators p)
            {
                Count -= 2 * p.getCount();
                int i = Count / 2;
                if (Count < 0)
                {
                    Count = 0;
                }
                return i;
            }
            public override void Turn()
            {
                turns++;
                if (turns == 4)
                {
                    Count *= 2;
                    if (Count > 200)
                    {
                        Count = 40;
                    }
                    turns = 0;
                }
            }
        }
        public class SnowyOwl : Predators
        {
            public SnowyOwl(string name, int nr)
            {
                if (nr < 0) throw new ArgumentOutOfRangeException();
                this.name = name;
                this.Count = nr;
                this.startval = nr;
            }
            public override void Attack(List<Prey> preys)
            {
                if (preys == null || preys.Count == 0) { return; }
                turns++;
                int remained = preys[rand.Next(preys.Count)].AttackedBy(this);
                if (remained < 0)
                {
                    Count += remained / 4;
                }
                if (turns == 8)
                {
                    turns = 0;
                    Count += remained / 4;
                }

            }
        }

        public class ArcticFox : Predators
        {
            public ArcticFox(string name, int nr)
            {
                if (nr < 0) throw new ArgumentOutOfRangeException();
                this.name = name;
                this.Count = nr;
                this.startval = nr;
            }
            public override void Attack(List<Prey> preys)
            {
                turns++;
                int remained = preys[rand.Next(preys.Count)].AttackedBy(this);

                if (remained < 0)
                {
                    Count += remained / 4;
                }
                if (turns == 8)
                {
                    turns = 0;
                    Count += 3 * (Count / 4);
                }
            }
        }


        public class Wolf : Predators
        {
            public Wolf(string name, int nr)
            {
                if (nr < 0) throw new ArgumentOutOfRangeException();

                this.name = name;
                this.Count = nr;
                this.startval = nr;

            }
            public override void Attack(List<Prey> preys)
            {
                turns++;
                int remained = preys[rand.Next(preys.Count)].AttackedBy(this);


                if (remained < 0)
                {
                    Count += remained / 4;
                }

                if (turns == 8)
                {
                    turns = 0;
                    Count += 2 * (Count / 4);
                }
            }
        }


    }

}



