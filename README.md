8 Taş Bulmacası Çözümü - A* Algoritması (C# Windows Forms)


Bu projede, klasik 8 taş bulmacası problemi için A* (A Star) arama algoritması kullanılarak çözüm geliştirilmiştir. 

Uygulama C# programlama diliyle ve Windows Forms kullanılarak görsel bir arayüz üzerinden çalışacak şekilde tasarlanmıştır.

Projede hazır bir algoritma veya kütüphane kullanılmamıştır. Tüm işlemler kullanıcı girdilerine göre dinamik olarak gerçekleştirilir.

🎮 Uygulama Özellikleri
Başlangıç ve hedef durum kullanıcı tarafından girilebilir.

Girişler kontrol edilerek geçerli olmayan dizilimler engellenir.

A* algoritması çalıştırıldığında:

Her adımda hamle edilen taşlar ve yönü listelenir.

Tahtanın her adımda aldığı yeni durumlar görsel olarak gösterilir.

Çözüm adımları ekranın sağ kısmında listelenir.

Kullanıcı arayüzü, çözüm yolunu ve oyun alanını kolayca takip etmeye olanak tanır.

“Çöz” butonuna basıldığında, çözüm araması başlar ve adımlar anlık olarak görüntülenir.

🧠 Algoritma Bilgisi
Kullanılan algoritma: A* Arama Algoritması

A* algoritması, F(n) = G(n) + H(n) maliyet fonksiyonu ile çalışır:

G(n): Başlangıç durumundan mevcut duruma kadar yapılan hamle sayısı.

H(n): Mevcut durumun hedef duruma olan tahmini maliyeti (bu projede Manhattan uzaklığı kullanılmıştır).

Manhattan uzaklığı: Her bir taşın olması gereken konum ile bulunduğu konum arasındaki satır ve sütun farklarının toplamı.

Bu sayede algoritma hem geçmiş maliyetleri hem de gelecekteki olası maliyetleri değerlendirerek optimal çözümü bulur.


🖥️ Ekran Görüntüsü

![image](https://github.com/user-attachments/assets/027560a5-870b-4bfe-a203-2fe54bb12191)

![image](https://github.com/user-attachments/assets/15035838-d037-4286-a8d8-ba72c9f9192b)


💡 Kullanım
Uygulamayı Program.cs başlangıç noktası seçerek çalıştırın.

"Başlangıç" ve "Hedef" alanlarına virgül ile ayrılmış 0–8 arası sayıları girin. 

Örnek:

Başlangıç: 4,1,3,2,8,5,7,0,6

Hedef: 1,2,3,4,5,6,7,8,0

"Çöz" butonuna tıklayın.

Algoritma çalıştırılır ve sonuç çözüm adımlarıyla birlikte listelenir.

Adımlar ve çözüm ekranından işlemi takip edebilirsiniz.
