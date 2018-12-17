using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace OverwatchHeroPicker
{
    public class Hero
    {
        public string Name { get; set; }
        public string Role { get; set; }
        public string FileName { get; set; }

        public Hero(string name, string role, string fileName)
        {
            Name = name;
            Role = role;
            FileName = fileName;
        }

        public Hero()
        {

        }


    }

    public class Heroes : List<Hero>
    {
        public string FilterName { get; set; }


        public void Seed()
        {
            //Popular with all of the heros
            Hero Ana = new Hero("Ana", "Support", "ana.png");
            this.Add(Ana);

            Hero Ashe = new Hero("Ashe", "Damage", "ashe.png");
            this.Add(Ashe);

            Hero Bastion = new Hero("Bastion", "Damage", "bastion.png");
            this.Add(Bastion);

            Hero Brigitte = new Hero("Brigitte", "Support", "brigitte.png");
            this.Add(Brigitte);

            Hero Dva = new Hero("D.va", "Tank", "dva.png");
            this.Add(Dva);

            Hero Doomfist = new Hero("Doomfist", "Damage", "doomfist.png");
            this.Add(Doomfist);

            Hero Genji = new Hero("Genji", "Damage", "genji.png");
            this.Add(Genji);

            Hero Hanzo = new Hero("Hanzo", "Damage", "hanzo.png");
            this.Add(Hanzo);

            Hero Junkrat = new Hero("Junkrat", "Damage", "junkrat.png");
            this.Add(Junkrat);

            Hero Lucio = new Hero("Lucio", "Support", "lucio.png");
            this.Add(Lucio);

            Hero Mccree = new Hero("McCree", "Damage", "mccree.png");
            this.Add(Mccree);

            Hero Mei = new Hero("Mei", "Damage", "mei.png");
            this.Add(Mei);

            Hero Mercy = new Hero("Mercy", "Support", "mercy.png");
            this.Add(Mercy);

            Hero Moira = new Hero("Moira", "Support", "moira.png");
            this.Add(Moira);

            Hero Orisa = new Hero("Orisa", "Tank", "orisa.png");
            this.Add(Orisa);

            Hero Pharah = new Hero("Pharah", "Damage", "pharah.png");
            this.Add(Pharah);

            Hero Reaper = new Hero("Reaper", "Damage", "reaper.png");
            this.Add(Reaper);

            Hero Reinhardt = new Hero("Reinhardt", "Tank", "reinhardt.png");
            this.Add(Reinhardt);

            Hero Roadhog = new Hero("Roadhog", "Tank", "roadhog.png");
            this.Add(Roadhog);

            Hero Soldier = new Hero("Soldier 76", "Damage", "soldier.png");
            this.Add(Soldier);

            Hero Sombra = new Hero("Sombra", "Damage", "sombra.png");
            this.Add(Sombra);

            Hero Symmetra = new Hero("Symmetra", "Damage", "symmetra.png");
            this.Add(Symmetra);

            Hero Torb = new Hero("Torbjörn", "Damage", "torb.png");
            this.Add(Torb);

            Hero Tracer = new Hero("Tracer", "Damage", "tracer.png");
            this.Add(Tracer);

            Hero Widowmaker = new Hero("Widowmaker", "Damage", "widowmaker.png");
            this.Add(Widowmaker);

            Hero Winston = new Hero("Winston", "Tank", "winston.png");
            this.Add(Winston);

            Hero Wreckingball = new Hero("Wrecking Ball", "Tank", "wreckingball.png");
            this.Add(Wreckingball);

            Hero Zarya = new Hero("Zarya", "Tank", "zarya.png");
            this.Add(Zarya);

            Hero Zenyatta = new Hero("Zenyatta", "Support", "zenyatta.png");
            this.Add(Zenyatta);

        }
    }

    public class Filters : List<Heroes>
    {

    }
}
