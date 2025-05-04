using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace AStarAlgoritmasi8TasBulmacasi
{
    public partial class AStar8Bulmaca : Form
    {
        public AStar8Bulmaca()
        {
            InitializeComponent();
        }

        int[,] baslangicDurumu;
        public static int[,] amacDurumu;
        int selected_depth = 0;
        bool found = false;
        int Max_Depth = 30;

        node node = new node();  // Çözüm araması yapacak olan node nesnesi

        // Print path fonksiyonu, çözümü adım adım yazdırır
        void print_path(int[,] state, string action)
        {
            int[,] currect_state = state;

            // Yapılacak hareketi belirleyerek durumu güncelleriz
            if (action == "right")
            {
                currect_state = node.left(currect_state);
                node.actions.Add("right");
            }
            else if (action == "left")
            {
                currect_state = node.right(currect_state);
                node.actions.Add("left");
            }
            else if (action == "up")
            {
                currect_state = node.down(currect_state);
                node.actions.Add("up");
            }
            else if (action == "down")
            {
                currect_state = node.up(currect_state);
                node.actions.Add("down");
            }

            // Başlangıç durumuna geri dönene kadar hareketleri yazdır
            while (!node.match_array(currect_state, baslangicDurumu))
            {
                string currect_action = node.get_action(currect_state);

                if (currect_action == "right")
                {
                    currect_state = node.left(currect_state);
                    node.actions.Add("right");
                }
                else if (currect_action == "left")
                {
                    currect_state = node.right(currect_state);
                    node.actions.Add("left");
                }
                else if (currect_action == "up")
                {
                    currect_state = node.down(currect_state);
                    node.actions.Add("up");
                }
                else if (currect_action == "down")
                {
                    currect_state = node.up(currect_state);
                    node.actions.Add("down");
                }
            }

            // Çözümün tamamını ters sırayla yazdır
            for (int a = node.actions.Count - 1; a >= 0; a--)
            {
                if (node.actions[a] == "right ")
                {
                    currect_state = node.right(currect_state);
                }
                else if (node.actions[a] == "left ")
                {
                    currect_state = node.left(currect_state);
                }
                else if (node.actions[a] == "up ")
                {
                    currect_state = node.up(currect_state);
                }
                else if (node.actions[a] == "down ")
                {
                    currect_state = node.down(currect_state);
                }

                // Adım adım durumu yazdır
                print_state(currect_state);
            }
        }

        // Durumları ekranda yazdırma fonksiyonu
        void print_state(int[,] state)
        {
            string to_print = "";

            // 3x3'lük bir diziyi string'e çevirir ve ekrana yazdırır
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 3; i++)
                {
                    to_print += state[j, i] + " ";
                }
                to_print += "\r\n";
            }
            txtSonuc.Text += to_print + Environment.NewLine;  // Sonuçları TextBox'a yazdırır
        }

        // Başlangıç durumunu doğru formatta almak için tuşa basıldığında sadece rakam ve virgül girilmesini sağlar
        private void txtBaslangic_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ',';  // Sayı ve virgül dışında bir şey girilemez
        }

        // Çözüm butonuna tıklandığında çözüm işlemi başlar
        private void btnCoz_Click(object sender, EventArgs e)
        {
            txtSonuc.Text = "";  // Sonuçları temizler
            txtActions.Text = "";  // Yapılan hareketleri temizler
            selected_depth = 0;  // Başlangıç derinliği
            found = false;  // Başlangıçta çözüm bulunmamış olarak ayarlanır
            Max_Depth = 30;  // Maksimum derinlik
            baslangicDurumu = new int[3, 3];  // Başlangıç durumu sıfırlanır
            amacDurumu = new int[3, 3];  // Amaç durumu sıfırlanır
            node.FrontHere.Clear();  // Çözüme yönlendiren öncelik sırasındaki düğümler sıfırlanır
            node.CheckedList.Clear();  // Kontrol edilen durumlar sıfırlanır
            node.actions.Clear();  // Yapılan hareketler sıfırlanır

            // Başlangıç ve amaç durumu kullanıcıdan alındı, virgülle ayrılmış şekilde dizilere aktarılır
            string[] bSayilar = txtBaslangic.Text.Split(',');
            string[] aSayilar = txtAmac.Text.Split(',');

            // Eğer eksik veri girilmişse kullanıcıya uyarı gösterilir
            if (aSayilar.Length < 9 || bSayilar.Length < 9 || aSayilar.Contains("") || bSayilar.Contains(""))
            {
                MessageBox.Show("Lütfen 9 Sayı Giriniz ve virgül ile ayırınız ");
                return;
            }

            // Başlangıç durumunun dizilere aktarılması
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    baslangicDurumu[i, j] = int.Parse(bSayilar[count++]);
                }
            }

            // Amaç durumunun dizilere aktarılması
            count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    amacDurumu[i, j] = int.Parse(aSayilar[count++]);
                }
            }

            // Başlangıç durumuyla çözüm aramaya başlarız
            node start = new node()
            {
                state = baslangicDurumu,  // Başlangıç durumu
                depth = 0  // Başlangıç derinliği
            };

            node.FrontHere.Add(start);  // FrontHere listesine başlama durumunu ekleriz

            node get_state()  // Bu fonksiyon, en düşük f-değeri olan durumu alır
            {
                node what = new node();
                int index = 0;
                int selected_index = 0;
                int min_f = Max_Depth + 9;

                // FrontHere listesinde en uygun durumu seçeriz
                foreach (node nd in node.FrontHere)
                {
                    if (nd.depth + node.h(nd.state) < min_f)
                    {
                        min_f = nd.depth + node.h(nd.state);
                        what.state = nd.state;
                        what.depth = nd.depth;
                        what.action = nd.action;
                        selected_index = index;
                    }
                    index++;
                }

                node.FrontHere.RemoveAt(selected_index);  // Seçilen durumu listeden çıkarırız
                return what;
            }

            // Başlangıç durumunu ekranda yazdırırız
            print_state(baslangicDurumu);

            // Aşağıdaki while döngüsü çözüm bulunduğunda veya maksimum derinlik aşıldığında sonlanır
            while (node.FrontHere.Count != 0 && !found && selected_depth <= Max_Depth)
            {
                node best_result = get_state();  // En uygun durumu alırız
                if (node.match_array(best_result.state, amacDurumu))  // Amaç durumu bulunduysa çözüm yazdırılır
                {
                    print_path(best_result.state, best_result.action);  // Çözüm yolu yazdırılır
                    found = true;
                    MessageBox.Show("Çözüm bulundu");  // Çözüm bulunduğu için mesaj gösterilir
                    printUI(baslangicDurumu);  // Başlangıç durumunu UI'da göster
                    startTable();  // Adım adım çözümü başlatır
                }
                else
                {
                    // Yukarı, aşağı, sağa, sola hareketleri kontrol eder ve çözümü yönlendiren yeni düğümleri oluşturur
                    if (node.canRight(best_result.state) && !node.wasChecked(node.right(best_result.state)))
                    {
                        node data = new node();
                        data.depth = best_result.depth + 1;
                        data.state = node.right(best_result.state);
                        data.action = "right";

                        node.FrontHere.Add(data);  // Yeni düğüm eklenir
                    }

                    if (node.canLeft(best_result.state) && !node.wasChecked(node.left(best_result.state)))
                    {
                        node data = new node();
                        data.depth = best_result.depth + 1;
                        data.state = node.left(best_result.state);
                        data.action = "left";

                        node.FrontHere.Add(data);  // Yeni düğüm eklenir
                    }

                    if (node.canDown(best_result.state) && !node.wasChecked(node.down(best_result.state)))
                    {
                        node data = new node();
                        data.depth = best_result.depth + 1;
                        data.state = node.down(best_result.state);
                        data.action = "down";

                        node.FrontHere.Add(data);  // Yeni düğüm eklenir
                    }

                    if (node.canUp(best_result.state) && !node.wasChecked(node.up(best_result.state)))
                    {
                        node data = new node();
                        data.depth = best_result.depth + 1;
                        data.state = node.up(best_result.state);
                        data.action = "up";

                        node.FrontHere.Add(data);  // Yeni düğüm eklenir
                    }

                    selected_depth = best_result.depth;  // Derinlik güncellenir
                    node.CheckedList.Add(best_result);  // Kontrol edilen durumlar listesine eklenir
                }

                // Maksimum derinlik aşılınca çözüm bulunamadığı bildirilir
                if (selected_depth > Max_Depth)
                {
                    MessageBox.Show("Çözüm bulunamadı");
                    return;
                }
            }

        }

        // UI üzerinde başlangıç durumunu oluşturur
        void printUI(int[,] state)
        {
            int a = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                { //Adımların gösterildiği 3x3 tablo
                    Button btn = new Button();
                    btn.Name = "button" + a.ToString();
                    btn.Text = state[i, j].ToString();
                    btn.Size = new System.Drawing.Size(75, 85);
                    btn.BackColor = Color.LightGreen;
                    btn.ForeColor = Color.White;
                    int size = 20;
                    btn.Font = new Font(btn.Font.FontFamily, size);
                    btn.Location = new Point(78 + (j * 81), 181 + (i * 91) + 30);

                    this.Controls.Add(btn);
                    a++;
                }
            }
        }

        int zeroLocation1;
        int zeroLocation2;

        // Tabloyu başlatan fonksiyon
        void startTable()
        {
            zeroLocation1 = node.zero_position(baslangicDurumu);
            zeroLocation2 = node.zero_position(baslangicDurumu, false);

            // Yapılan hareketlere göre UI'yi günceller
            for (int i = node.actions.Count - 1; i >= 0; i--)
            {
                MessageBox.Show(node.actions[i]);
                if (node.actions[i] == "left")
                {
                    leftUI(zeroLocation1, zeroLocation2);
                }
                else if (node.actions[i] == "right")
                {
                    rightUI(zeroLocation1, zeroLocation2);
                }
                else if (node.actions[i] == "up")
                {
                    upUI(zeroLocation1, zeroLocation2);
                }
                else if (node.actions[i] == "down")
                {
                    downUI(zeroLocation1, zeroLocation2);
                }
                txtActions.Text += node.actions[i] + " ";  // Yapılan hareketler yazdırılır
                System.Threading.Thread.Sleep(500);  // Her adım arasında 0,5 saniye bekler
            }
        }

        // Sağ hareket fonksiyonu
        void rightUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;
            Button number = this.Controls.Find("button" + (a + 1), true).FirstOrDefault() as Button;
            zeroLocation2 = j + 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        // Sol hareket fonksiyonu
        void leftUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;
            Button number = this.Controls.Find("button" + (a - 1), true).FirstOrDefault() as Button;
            zeroLocation2 = j - 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        // Yukarı hareket fonksiyonu
        void upUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;
            Button number = this.Controls.Find("button" + (a - 3), true).FirstOrDefault() as Button;
            zeroLocation1 = i - 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        // Aşağı hareket fonksiyonu
        void downUI(int i, int j)
        {
            int a = numberUI(i, j);

            Button zero = this.Controls.Find("button" + a, true).FirstOrDefault() as Button;
            Button number = this.Controls.Find("button" + (a + 3), true).FirstOrDefault() as Button;
            zeroLocation1 = i + 1;
            zero.Text = number.Text;
            number.Text = "0";
        }

        // Buton numarasını hesaplama fonksiyonu
        int numberUI(int i, int j)
        {
            int a = i * 3 + j;
            return a;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void txtBaslangic_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtSonuc_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void AStar8Bulmaca_Load(object sender, EventArgs e)
        {

        }
    }
}