using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonumentManager.Model
{
    class SculptureCatalogSingleton
    {
        //Instanciate the singleton
        private static SculptureCatalogSingleton instance = new SculptureCatalogSingleton();

        public static SculptureCatalogSingleton Instance
        {
            get { return instance; }
        }

        //Actual Hotel Collection
        public ObservableCollection<SculptureModel> Sculptures { get; set; }

        private SculptureCatalogSingleton()
        {
            Sculptures = new ObservableCollection<SculptureModel>();
            //These three should be commented out or removed once we import data from our database
            SculptureModel s1 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s2 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s3 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s4 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s5 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s6 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s7 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s8 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s9 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s10 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s11 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s12 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s13 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s14 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s15 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s16 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s17 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s18 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s19 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s20 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s21 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s22 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s23 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s24 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s25 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s26 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s27 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            SculptureModel s28 = new SculptureModel(1, "Den Lille Havfrue", "Gørtlersgade 15", "Havnen", "ms-appx:///Assets/Pictures/Picture1_havfrue.jpg", 1, 5, false);
            SculptureModel s29 = new SculptureModel(2, "Løverne", "Strøget 132", "Jorden", "ms-appx:///Assets/Pictures/Picture2_loever.jpg", 2, 10, false);
            SculptureModel s30 = new SculptureModel(3, "Rytter Absalon", "Ørstedsparken", "Jorden", "ms-appx:///Assets/Pictures/Picture3_rytter.jpg", 3, 7, false);
            Sculptures.Add(s1);
            Sculptures.Add(s2);
            Sculptures.Add(s3);
            Sculptures.Add(s4);
            Sculptures.Add(s5);
            Sculptures.Add(s6);
            Sculptures.Add(s7);
            Sculptures.Add(s8);
            Sculptures.Add(s9);
            Sculptures.Add(s10);
            Sculptures.Add(s11);
            Sculptures.Add(s12);
            Sculptures.Add(s13);
            Sculptures.Add(s14);
            Sculptures.Add(s15);
            Sculptures.Add(s16);
            Sculptures.Add(s17);
            Sculptures.Add(s18);
            Sculptures.Add(s19);
            Sculptures.Add(s20);
            Sculptures.Add(s21);
            Sculptures.Add(s22);
            Sculptures.Add(s23);
            Sculptures.Add(s24);
            Sculptures.Add(s25);
            Sculptures.Add(s26);
            Sculptures.Add(s27);
            Sculptures.Add(s28);
            Sculptures.Add(s29);
            Sculptures.Add(s30);

            //This is to get data from the database, dont think about for now!
            //Sculptures = new ObservableCollection<SculptureModel>(new PersistenceFacade().GetSculptures());
        }

        //Add to SculptureCatalog Method
        public void Add(int id, string name, string address, string placement, string picture, int inspectionId, int inspectionFrequency, bool doNotInspect)
        {
            Sculptures.Add(new SculptureModel(id, name, address, placement, picture, inspectionId, inspectionFrequency, doNotInspect));
        }
    }
}
