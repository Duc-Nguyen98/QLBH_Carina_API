using System;
using System.Windows.Forms;

namespace BT_lon
{
    public partial class Huong_Su_Dung : UserControl
    {
        public Huong_Su_Dung()
        {
            InitializeComponent();
        }

        private void btn_trangchu_Click(object sender, EventArgs e)
        {

        }

        private void btn_san_pham_Click(object sender, EventArgs e)
        {
            HDSD_San_Pham show = new HDSD_San_Pham();
            show.ShowDialog();
        }

        private void btn_nhan_vien_Click(object sender, EventArgs e)
        {
            HDSD_Nhan_Vien f3x = new HDSD_Nhan_Vien();
            f3x.ShowDialog();
        }

        private void btn_hoa_don_Click(object sender, EventArgs e)
        {
            HDSD_Hoa_Don show = new HDSD_Hoa_Don();
            show.ShowDialog();
        }

        private void btn_nha_cung_cap_Click(object sender, EventArgs e)
        {
            HDSD_Nha_Cung_Cap f3x = new HDSD_Nha_Cung_Cap();
            f3x.ShowDialog();
        }

        private void btn_khach_hang_Click(object sender, EventArgs e)
        {
            HDSD_Khach_Hang show = new HDSD_Khach_Hang();
            show.ShowDialog();
        }

        private void Huong_dan_su_dung(object sender, EventArgs e)
        {

        }
    }
}
