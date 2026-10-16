namespace manavProjesi
{
    internal class Program
    {
        
        static void Main(string[] args)
        {
            Toptancı toptancı = new Toptancı();
            Manav manav = new Manav();
            Musteri musteri = new Musteri();

            halMenusu(toptancı,manav);
            manavStokGoster(manav);
            MusteriMenusu(manav, musteri);

            Console.WriteLine("\n--- Alışveriş sonrası kalan stoklar ---");
            manavStokGoster(manav);
            
        }

        static void halMenusu(Toptancı toptancı,Manav manav)
        {
            while (true)
            {
                Console.WriteLine("Hale hoşgeldiniz");
                Console.WriteLine("Meyve için M ye , Sebze için S ye basınız");
                Console.WriteLine("Hal alışverişini bitirmek için 0 a basınız");

                string secim = Console.ReadLine().ToUpper();

                if(secim == "0")
                {
                    return;
                }
                else if(secim == "M")
                {
                    Console.WriteLine("Toptancının meyve listesi");

                    foreach(Urun urun in toptancı.meyveler)
                    {
                        Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
                    }
                    urunSec(toptancı.meyveler,manav.meyveler);


                }else if(secim == "S")
                {
                    Console.WriteLine("Toptancının sebzeleri");

                    foreach(Urun urun in toptancı.sebzeler)
                    {
                        Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
                    }
                    urunSec(toptancı.sebzeler,manav.sebzeler);

                }
                else
                {
                    Console.WriteLine("Geçersiz seçim");
                }
            }
        }
        static void urunSec(List<Urun> urunler,List<Urun> manavUrunleri)
        {
            while (true)
            {
                Console.WriteLine("Almak istediğiniz ürünün adını yazınız :");
                string urunAdı = Console.ReadLine().ToUpper();

                foreach(Urun urun in urunler)
                {
                    if(urun.ad.ToUpper() == urunAdı)
                    {
                        while (true)
                        {
                            Console.WriteLine("Kaç kilo almak istiyorsunuz ?");
                            decimal kilo;

                            if(decimal.TryParse(Console.ReadLine(), out kilo) && kilo > 0)
                            {
                                if (kilo > urun.kilo)
                                {
                                    Console.WriteLine("Yeterli stok yok");
                                    Console.WriteLine("Mevcut stok " + urun.kilo + " kg");
                                    continue;
                                }

                                urun.kilo-=kilo;

                                bool urunVarMi = false;

                                foreach(Urun manavUrunu in manavUrunleri)
                                {
                                    if(manavUrunu.ad.ToUpper() == urun.ad.ToUpper())
                                    {
                                        manavUrunu.kilo += kilo;
                                        urunVarMi= true;
                                        break;
                                    }
                                }

                                if(urunVarMi == false)
                                {
                                    Urun yeniUrun = new Urun();
                                    yeniUrun.ad = urun.ad;
                                    yeniUrun.kilo = kilo;

                                    manavUrunleri.Add(yeniUrun);
                                }

                                Console.WriteLine(kilo + " kg " + urun.ad + " aldınız");
                                Console.WriteLine("Kalan stok: " + urun.kilo + " kg");

                                return;
                            }

                            Console.WriteLine("Sıfırdan büyük bir sayı giriniz");
                        }
                    }
                }

                Console.WriteLine("Bu ürün listede yok.Tekrar deneyiniz");
            }
        }

        static void manavStokGoster(Manav manav)
        {
            Console.WriteLine("\n--- Manavın Meyveleri ---");

            if(manav.meyveler.Count == 0)
            {
                Console.WriteLine("Meyve yok");
            }

            foreach(Urun urun in manav.meyveler)
            {
                Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
            }

            Console.WriteLine("\n--- Manavın Sebzeleri ---");

            if(manav.sebzeler.Count == 0)
            {
                Console.WriteLine("Sebze yok");
            }

            foreach(Urun urun in manav.sebzeler)
            {
                Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
            }
        }

        static void MusteriMenusu(Manav manav,Musteri musteri)
        {
            while (true)
            {
                Console.WriteLine("\nMeyve almak için M");
                Console.WriteLine("Sebze almak için S");
                Console.WriteLine("Alışverişi bitirmek için 0");

                string secim = Console.ReadLine().ToUpper();

                if(secim == "0")
                {
                    Console.WriteLine("\n--- Aldığınız Ürünler ---");

                    if(musteri.alinanUrunler.Count == 0)
                    {
                        Console.WriteLine("Hiç ürün almadınız");
                    }

                    foreach(Urun urun in musteri.alinanUrunler)
                    {
                        Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
                    }

                    Console.WriteLine("Alışverişiniz bitti");
                    return;

                }
                else if(secim == "M")
                {
                    if(manav.meyveler.Count == 0)
                    {
                        Console.WriteLine("Manavda meyve yok");
                        continue;
                    }

                    foreach(Urun urun in manav.meyveler)
                    {
                        Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
                    }

                    urunSec(manav.meyveler, musteri.alinanUrunler);
                }
                else if (secim == "S")
                {
                    if(manav.sebzeler.Count == 0)
                    {
                        Console.WriteLine("Manavda sebze yok");
                        continue;
                    }

                    foreach(Urun urun in manav.sebzeler)
                    {
                        Console.WriteLine(urun.ad + ": " + urun.kilo + " kg");
                    }

                    urunSec(manav.sebzeler, musteri.alinanUrunler);
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim.");
                }
            }
        }
    }
}
