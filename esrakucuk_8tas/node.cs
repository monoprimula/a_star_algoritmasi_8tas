using System.Collections.Generic;
using System;

namespace AStarAlgoritmasi8TasBulmacasi
{
    class node
    {
        public int[,] state;  
        public string action; 
        public int depth; 

        public List<node> FrontHere = new List<node>();  // Önceki düğümlerin tutulduğu liste
        public List<node> CheckedList = new List<node>(); // Kontrol edilen düğümlerin tutulduğu liste
        public List<string> actions = new List<string>(); // Yapılan hareketlerin listesi

        // Sağ hareket yapılabilir mi? Kontrol eder
        public bool canRight(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[i, 2] == 0) // Sağdaki sütunda boşluk varsa, sağa kaydırılamaz
                {
                    return false;
                }
            }
            return true; // Sağdaki sütunda boşluk yoksa, sağa kaydırılabilir
        }

        // Sol hareket yapılabilir mi? Kontrol eder
        public bool canLeft(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[i, 0] == 0) // Soldaki sütunda boşluk varsa, sola kaydırılamaz
                {
                    return false;
                }
            }
            return true; // Soldaki sütunda boşluk yoksa, sola kaydırılabilir
        }

        // Yukarı hareket yapılabilir mi? Kontrol eder
        public bool canUp(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[0, i] == 0) // Üst satırda boşluk varsa, yukarı kaydırılamaz
                {
                    return false;
                }
            }
            return true; // Üst satırda boşluk yoksa, yukarı kaydırılabilir
        }

        // Aşağı hareket yapılabilir mi? Kontrol eder
        public bool canDown(int[,] state)
        {
            for (int i = 0; i < 3; i++)
            {
                if (state[2, i] == 0) // Alt satırda boşluk varsa, aşağı kaydırılamaz
                {
                    return false;
                }
            }
            return true; // Alt satırda boşluk yoksa, aşağı kaydırılabilir
        }

        // Sağa kaydırma işlemi gerçekleştirilir
        public int[,] right(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            // Bulmacanın mevcut durumunu kopyalar
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            int i = zero_position(state); // 0'ın (boşluğun) bulunduğu satır
            int j = zero_position(state, false); // 0'ın (boşluğun) bulunduğu sütun

            // Boşluk ile sağındaki değeri takas yapar
            what[i, j] = state[i, j + 1];
            what[i, j + 1] = 0;

            Console.WriteLine("Sağa hareket yapıldı."); // Ekrana sağa kaydırıldığını belirtir
            return what; // Yeni durumu döndürür
        }

        // Sola kaydırma işlemi gerçekleştirilir
        public int[,] left(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            // Bulmacanın mevcut durumunu kopyalar
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            int i = zero_position(state); // 0'ın (boşluğun) bulunduğu satır
            int j = zero_position(state, false); // 0'ın (boşluğun) bulunduğu sütun

            // Boşluk ile solundaki değeri takas yapar
            what[i, j] = state[i, j - 1];
            what[i, j - 1] = 0;

            Console.WriteLine("Sola hareket yapıldı."); // Ekrana sola kaydırıldığını belirtir
            return what; // Yeni durumu döndürür
        }

        // Yukarı kaydırma işlemi gerçekleştirilir
        public int[,] up(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            // Bulmacanın mevcut durumunu kopyalar
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            int i = zero_position(state); // 0'ın (boşluğun) bulunduğu satır
            int j = zero_position(state, false); // 0'ın (boşluğun) bulunduğu sütun

            // Boşluk ile yukarıdaki değeri takas yapar
            what[i, j] = state[i - 1, j];
            what[i - 1, j] = 0;

            Console.WriteLine("Yukarı hareket yapıldı."); // Ekrana yukarı kaydırıldığını belirtir
            return what; // Yeni durumu döndürür
        }

        // Aşağı kaydırma işlemi gerçekleştirilir
        public int[,] down(int[,] state)
        {
            int[,] what = new int[,]
            {
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 },
                    { 0 , 0 , 0 }
            };

            // Bulmacanın mevcut durumunu kopyalar
            for (int h = 0; h < 3; h++)
            {
                for (int w = 0; w < 3; w++)
                {
                    what[h, w] = state[h, w];
                }
            }

            int i = zero_position(state); // 0'ın (boşluğun) bulunduğu satır
            int j = zero_position(state, false); // 0'ın (boşluğun) bulunduğu sütun

            // Boşluk ile altındaki değeri takas yapar
            what[i, j] = state[i + 1, j];
            what[i + 1, j] = 0;

            Console.WriteLine("Aşağı hareket yapıldı."); // Ekrana aşağı kaydırıldığını belirtir
            return what; // Yeni durumu döndürür
        }

        // 0'ın (boşluğun) bulunduğu satırı döndürür
        public int zero_position(int[,] state, bool d = true)
        {
            int what = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == 0)
                    {
                        if (d)
                            what = i; // satır
                        else
                            what = j; // sütun
                    }
                }
            }
            return what;
        }

        // Durum daha önce kontrol edilmiş mi? Kontrol eder
        public bool wasChecked(int[,] state)
        {
            bool what = false;

            // Kontrol edilen her durumu kontrol eder
            foreach (node nd in CheckedList)
            {
                if (match_array(nd.state, state)) // Eğer aynı durum varsa, zaten kontrol edilmiştir
                {
                    what = true;
                }
            }
            return what; // Durum daha önce kontrol edilmişse true döner
        }

        // İki durumu karşılaştırır
        public bool match_array(int[,] state1, int[,] state2)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state1[i, j] != state2[i, j]) // Durumlar eşleşmiyorsa false döner
                        return false;
                }
            }
            return true; // Durumlar eşleşiyorsa true döner
        }

        // Hedef duruma ne kadar uzak olduğunu hesaplar (hueristik fonksiyon)
        public int h(int[,] state)
        {
            int match = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (state[i, j] == AStar8Bulmaca.amacDurumu[i, j]) match++; // Hedef durumla aynı olan taşları sayar
                }
            }
            return 9 - match; // Farklı taşların sayısı kadar uzaklık döner
        }

        // Durumun hangi hareketle elde edildiğini belirler
        public string get_action(int[,] state)
        {
            foreach (node nd in CheckedList)
            {
                if (match_array(nd.state, state)) // Eğer durum bulunursa, hangi hareketle elde edildiğini döner
                {
                    return nd.action;
                }
            }
            return "yok"; // Eğer durum bulunamazsa "yok" döner
        }
    }
}
