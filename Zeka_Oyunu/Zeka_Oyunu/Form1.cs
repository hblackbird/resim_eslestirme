using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace Zeka_Oyunu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Random rnd = new Random();
        List<Point> lokasyon = new List<Point>();
        PictureBox geciciresim1;
        PictureBox geciciresim2;
        int saniye = 0, dakika = 0;
        int bitti = 0;
        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (PictureBox resim in panel.Controls)
            {
                resim.Image = Properties.Resources.question_mark_draw;//ilk önce bütün pictureboxlara soru işareti resmi atanıyor.
                lokasyon.Add(resim.Location);//soru işareti atanan pictureboxların konumlarını lokasyon adlı değişkene ekliyoruz.
            }
            foreach (PictureBox resim in panel.Controls)
            {
                int siradaki = rnd.Next(lokasyon.Count);//pictureboxların lokasyonlarının büyüklüğüne kadar bir random değişken oluşturulur.
                Point p = lokasyon[siradaki];//point türünden bir değişkene bu yeni random lokasyon atanır.
                resim.Location = p;//point türündeki bu random lokasyon pictureboxlarımızın yeni lokasyonudur.
                lokasyon.Remove(p);//p lokasyonu yeni bir lokasyon alması için silinir.
            }
        }
        private void kazandi_mi()//kazandı mı kontrolü yapılır.
        {
            timer2.Stop();
            if (bitti == 8)//her eşleşen resimden sonra arttırılan bitti değişkeni en fazla 8 olabilir 8 olursa da oyun bitmiş demektir. 
            {
                MessageBox.Show(dakika+" dakika "+saniye+" saniyede"+" kazandınız");
            }
        }
        int tiklandi = 0,tag=0;
        private void resim_bul(object sender,EventArgs e)
        {
            timer2.Start();
            tiklandi++;
            PictureBox pic = (PictureBox)sender;
            tag = Convert.ToInt32(pic.Tag);//pictureboxların tag leri bir değişkene atanır
            if (tag == 1)//daha sonra bu taglere göre hangi picturebox a hangi resim geleceği belirlenir.
            {
                pic.Image = Properties.Resources.candy;
            }
            if (tag == 2)
            {
                pic.Image = Properties.Resources.clown_fish;
            }
            if (tag == 3)
            {
                pic.Image = Properties.Resources.flower;
            }
            if (tag == 4)
            {
                pic.Image = Properties.Resources.ladybug;
            }
            if (tag == 5)
            {
                pic.Image = Properties.Resources.ninja;
            }
            if (tag == 6)
            {
                pic.Image = Properties.Resources.santa_claus;
            }
            if (tag == 7)
            {
                pic.Image = Properties.Resources.snake;
            }
            if (tag == 8)
            {
                pic.Image = Properties.Resources.snowflake;
            }
            if (tiklandi == 1)//eğer picturebox a 1 kere tıklanırsa geciciresim1 adlı değişkenimizde bu picturebox atanır.
            {
                geciciresim1 = pic;
            }
            if (tiklandi == 2)//eğer pictureboxlara 2. kez tıklanırsa bu sefer 2 si arasında kontrol olması için geciciresim2 adlı değişkene atama yapılır. 
            {
                tiklandi = 0;
                geciciresim2 = pic;
            }
            
            if (geciciresim1 != null && geciciresim2 != null)//aynılar mı kontrolü için iki gecici resim değişkeninin boş mu dolu mu olduğu kontrol edilir.
            {
                if (geciciresim1.Tag == geciciresim2.Tag)//eğer bu açılan 2 pictureboxlar aynı ise resimler görünür kalır
                {
                    geciciresim1.Enabled = false;//açılan resimlere bir daha tıklanmaması için enabled özelliği false yapılır
                    geciciresim2.Enabled = false;
                    geciciresim1 = null;
                    geciciresim2 = null;
                    bitti++;
                    kazandi_mi();
                    tag = 0;
                }
                else//eğer aynı değillerse 1 saniye beklenir ve resimler kapanır.
                {
                    timer1.Start();
                }
            }
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            geciciresim1.Image = Properties.Resources.question_mark_draw;
            geciciresim2.Image = Properties.Resources.question_mark_draw;
            geciciresim1 = null;
            geciciresim2 = null;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            saniye++;
            if (saniye == 60)
            {
                dakika++;
            }
        }
    }
}
