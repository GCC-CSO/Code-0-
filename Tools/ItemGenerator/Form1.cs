using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.IO;

namespace ItemGenerator
{
    public partial class ItemGenerator : Form
    {
        public ItemGenerator()
        {
            InitializeComponent();
            CombatStyles = new List<CombatStyle>();
          

            OpenFileDialog aFile = new OpenFileDialog();
            aFile.ShowDialog();
            FileStream comIn = (FileStream) aFile.OpenFile();
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(List<CombatStyle>));
            List<CombatStyle> comList = new List<CombatStyle>((List<CombatStyle>)deserializer.ReadObject(comIn));

            for (int i = 0; i < comList.Count; i++)
                CombatStyles_List.Items.Add(comList[i].Name);
            
        }

        private void ItemTypeIn_Drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ItemTypeIn_Drop.SelectedItem.ToString() == "Item")
            {
                ItemSubTypeIn_Drop.Items.Clear();
                ItemSub_Panel.BringToFront();

            }


            else if (ItemTypeIn_Drop.SelectedItem.ToString() == "Weapon")
            {
                WeaponPanel.BringToFront();

                ItemSubTypeIn_Drop.Items.Clear();
                ItemSubTypeIn_Drop.Items.Add("Arrow");
                ItemSubTypeIn_Drop.Items.Add("Bow");
                ItemSubTypeIn_Drop.Items.Add("Dagger");
                ItemSubTypeIn_Drop.Items.Add("Sword");
                ItemSubTypeIn_Drop.Items.Add("Club");
                ItemSubTypeIn_Drop.Items.Add("Spear");
                

            }

            else if (ItemTypeIn_Drop.SelectedItem.ToString() == "Armor")
            {
                ArmorPanel.BringToFront();
                ItemSubTypeIn_Drop.Items.Clear();
                ItemSubTypeIn_Drop.Items.Add("Head");
                ItemSubTypeIn_Drop.Items.Add("Neck");
                ItemSubTypeIn_Drop.Items.Add("Chest");
                ItemSubTypeIn_Drop.Items.Add("Ring");
                ItemSubTypeIn_Drop.Items.Add("Legs");
                ItemSubTypeIn_Drop.Items.Add("Hands");
                ItemSubTypeIn_Drop.Items.Add("Feet");

            }
        }

        private void AddCombatStyle_Button_Click(object sender, EventArgs e)
        {
            if(CombatStyles_List.SelectedItem!=null)
                if(!WeapCombatStyles_List.Items.Contains(CombatStyles_List.SelectedItem))
                    WeapCombatStyles_List.Items.Add(CombatStyles_List.SelectedItem);
        }

        private void WeapRemoveCombatStyle_Button_Click(object sender, EventArgs e)
        {
            if(WeapCombatStyles_List.SelectedItem!=null)
            WeapCombatStyles_List.Items.Remove(WeapCombatStyles_List.SelectedItem);
        }

        private void CombatStyleAnimation_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog anime = new OpenFileDialog();

            if(anime.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                    CombatStyleAnimIn_Text.Text = anime.FileName;
            }
        
        }

        private void ItemGenImage_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog genImage = new OpenFileDialog();

            if (genImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ItemGenImageIn_Text.Text = genImage.FileName;
            }
        }

        private void ItemInvImage_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog invImage = new OpenFileDialog();

            if (invImage.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ItemGenImageIn_Text.Text = invImage.FileName;
            }
        }

        private void CombatStyleSaveAs_Button_Click_1(object sender, EventArgs e)
        {
            
            SaveFileDialog SaveDialog = new SaveFileDialog();
            SaveDialog.ShowDialog();
            if (SaveDialog.FileName != "")
            {      
                CombatAttributes Attri = new CombatAttributes(CombatStyleComAttrFireIn_Num.Value, CombatStyleComAttrIceIn_Num.Value, CombatStyleComAttrAirIn_Num.Value, CombatStyleComAttrEarthIn_Num.Value, CombatStyleComAttrSlashIn_Num.Value, CombatStyleComAttrBashIn_Num.Value, CombatStyleComAttrPierceIn_Num.Value);
                String Name = CombatStyleNameIn_Text.Text;
                String pFileLocation = CombatStylePClassIn_Text.Text;
                String animeFileLocation = CombatStyleAnimIn_Text.Text;
                CombatStyle style = new CombatStyle(Attri, Name ,pFileLocation, animeFileLocation);
                
                CombatStyles.Add(style);
                FileStream FileOut = (FileStream) SaveDialog.OpenFile();
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<CombatStyle>));
                serializer.WriteObject(FileOut, style);

            }            
            
        }
        List<CombatStyle> CombatStyles;

        private void ArmorPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CombatStyles_List_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            
        }

        private void CombatStyleSave_Button_Click(object sender, EventArgs e)
        {
            CombatAttributes Attri = new CombatAttributes(CombatStyleComAttrFireIn_Num.Value, CombatStyleComAttrIceIn_Num.Value, CombatStyleComAttrAirIn_Num.Value, CombatStyleComAttrEarthIn_Num.Value, CombatStyleComAttrSlashIn_Num.Value, CombatStyleComAttrBashIn_Num.Value, CombatStyleComAttrPierceIn_Num.Value);
            String Name = CombatStyleNameIn_Text.Text;
            String pFileLocation = CombatStylePClassIn_Text.Text;
            String animeFileLocation = CombatStyleAnimIn_Text.Text;
            CombatStyle style = new CombatStyle(Attri, Name, pFileLocation, animeFileLocation);

            CombatStyles.Add(style);
            
        }
       
       
    }
}
