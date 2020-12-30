using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vtysProje
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server = localhost; port = 5432; Database = Proje_2; user ID = postgres; password = yusufkayra54");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from kitap";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewKitap.DataSource = ds.Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from dil";

            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewDil.DataSource = ds.Tables[0];
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komutEkle = new NpgsqlCommand("insert into kitap(aciklama, dil_id, kitap_adi, sayfa_sayisi) values (@p1, @p2, @p3,@p4)", baglanti);
            komutEkle.Parameters.AddWithValue("@p1", txtKitapAciklama.Text);
            komutEkle.Parameters.AddWithValue("@p2", int.Parse(txtDilID.Text));
            komutEkle.Parameters.AddWithValue("@p3", txtKitapAdi.Text);
            komutEkle.Parameters.AddWithValue("@p4", int.Parse(txtSayfaSayisi.Text));
            komutEkle.ExecuteNonQuery();
            baglanti.Close();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komutSil = new NpgsqlCommand("Delete from kitap where id = @p1", baglanti);
            komutSil.Parameters.AddWithValue("@p1", int.Parse(txtKitapID.Text));
            komutSil.ExecuteNonQuery();

            baglanti.Close();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();

            NpgsqlCommand komutGuncelle = new NpgsqlCommand("update kitap set aciklama = @p1, dil_id = @p2, kitap_adi = @p3, sayfa_sayisi = @p4 where id = @p5", baglanti);
            komutGuncelle.Parameters.AddWithValue("@p1", txtKitapAciklama.Text);
            komutGuncelle.Parameters.AddWithValue("@p2", int.Parse(txtDilID.Text));
            komutGuncelle.Parameters.AddWithValue("@p3", txtKitapAdi.Text);
            komutGuncelle.Parameters.AddWithValue("@p4", int.Parse(txtSayfaSayisi.Text));
            komutGuncelle.Parameters.AddWithValue("@p5", int.Parse(txtKitapID.Text));
            komutGuncelle.ExecuteNonQuery();

            baglanti.Close();
        }
    }
}
