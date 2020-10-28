# Fresh Fruit
Fresh fruit adalah aplikasi input data sederhana yang lebih kearah program kasir untuk pelanggan toko buah

### Cara Menggunakan
- Untuk menginput data user tinggal mengklik tombol "Add" dan program akan menampilkannya langsung

### Kelebihan dan Kekurangan
#### - Kelebihan
- Mendata menjadi lebih mudah
- Dengan diberi gambar program menjadi menarik

#### - Kekurangan 
- Tidak ada fungsi Hapus atau Clear
- Tidak ada atribut prodak (Harga,Jumlah(Kg),Dll)
- Tidak ada data pelanggan

### Penjelasan Koding
Pada kali ini saya menggunakan Interface dan beberapa Class untuk membua program ini, yang pertama interface untuk fungsi onSucceed dan onFailed dan jembatan yang akan digunakan pada Class Controller dan yang lain. Berikut kodingan-nya : 

    interface BucketEventListener
    {
        void onSucceed(string message);
        void onFailed(string message);
    }

Setelah ada jembatan penghubung baru class lain bisa saling berhubungan.

    class Bucket
    {
        private int capacity;
        private List<Fruit> fruits;

        public Bucket(int capacity)
        {
            this.capacity = capacity;
            this.fruits = new List<Fruit>();
        }
    ...

Untuk Class Bucket digunakan untuk deklarasi nama buah nya.

    class Fruit
    {
        public string name { get; set; }

        public Fruit(string name)
        {
            this.name = name;
        }
        public string getName()
        {
            return this.name;
        }
    }

Pada Class Fruit ini digunakan untuk deklarasi dan pengambilan nama dari buah.

    class Seller
    {
        private string name;
        private BucketController bucket;

        public Seller(string name, BucketController bucket)
        {
            this.name = name;
            this.bucket = bucket;
        }

        public List<Fruit> findAll()
        {
            return this.bucket.findAll();
        }
        public void addFruit(Fruit fruit)
        {
            this.bucket.addFruit(fruit);
        }
    }

Class Seller digunakan untuk menghubungkan nama buah ke listbox.

    class BucketController
    {
        private Bucket bucket;
        private BucketEventListener eventListener;

        public BucketController(Bucket bucket, BucketEventListener eventListener)
        {
            this.bucket = bucket;
            this.eventListener = eventListener;
        }
        public void addFruit(Fruit fruit)
        {
            if (bucketIsOverload())
            {
                eventListener.onFailed("Ops, Keranjang Penuh");
            }
            else
            {
                this.bucket.insert(fruit);
                eventListener.onSucceed("Yey, Berhasil Ditambahkan");
            }
        }
    ...

Pada Class ini digunakan untuk menghubungkan bucket dan interface yang mana nantinya akan berfungsi tentang kapasitas dan input data.

    public partial class MainWindow : Window, BucketEventListener
    {
        Seller wahyu;
        public MainWindow()
        {
            InitializeComponent();
            Bucket KeranjangBuah = new Bucket(4);
            BucketController bucketController = new BucketController(KeranjangBuah, this);

            wahyu = new Seller("Wahyu", bucketController);
            ListBoxBucket.ItemsSource = KeranjangBuah.findAll();
        }
    ...

Dan yang terakhir Class MainWindow, tinggal deklarasi dan pangil memanggil dari fungsi yang sudah ada. Berikut hasil nya :

<img src="/FreshFruit/ScreenShot/Hasil.PNG" width="350"> 