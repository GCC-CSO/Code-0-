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
            
            WeaponCombatStyles = new List<CombatStyle>();
            CombatStyles = new List<CombatStyle>();
            Weapons = new List<Weapon>();
            InitializeComponent();

            

            CombatStyles_List.DisplayMember = "Name";
            WeapCombatStyles_List.DisplayMember = "Name";
        }

        List<CombatStyle> CombatStyles;
        List<CombatStyle> WeaponCombatStyles;
        List<Weapon> Weapons;
         FileStream saveStream;

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
                if (!WeapCombatStyles_List.Items.Contains(CombatStyles_List.SelectedItem))
                {
                    WeaponCombatStyles.Add((CombatStyle)CombatStyles_List.SelectedItem);
                    WeapCombatStyles_List.DataSource = new List<CombatStyle>(WeaponCombatStyles);
                }
        }

        private void WeapRemoveCombatStyle_Button_Click(object sender, EventArgs e)
        {
            if (WeapCombatStyles_List.SelectedItem != null)
            {
                WeaponCombatStyles.Remove((CombatStyle)WeapCombatStyles_List.SelectedItem);
                WeapCombatStyles_List.DataSource = new List<CombatStyle>(WeaponCombatStyles);
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
            CombatStyleDialogSaveAs();
            CombatStyleSave();
           
               
            
        }
        

        private void ArmorPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CombatStyles_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            
        }

        private void CombatStyleSave_Button_Click(object sender, EventArgs e)
        {
            if (CombatStyleNameIn_Text.Text != "")
            {
                CombatAttributes Attri = new CombatAttributes(CombatStyleComAttrFireIn_Num.Value, CombatStyleComAttrIceIn_Num.Value, CombatStyleComAttrAirIn_Num.Value, CombatStyleComAttrEarthIn_Num.Value, CombatStyleComAttrSlashIn_Num.Value, CombatStyleComAttrBashIn_Num.Value, CombatStyleComAttrPierceIn_Num.Value);
                String Name = CombatStyleNameIn_Text.Text;
                String pFileLocation = CombatStylePClassIn_Text.Text;
                String animeFileLocation = CombatStyleAnimIn_Text.Text;
                CombatStyle style = new CombatStyle(Attri, Name, pFileLocation, animeFileLocation);

                bool OK = true;
                List<CombatStyle> mock = new List<CombatStyle>(CombatStyles);
                foreach (CombatStyle styleCompare in mock)
                {
                    if (styleCompare.Equals(style))
                    {
                        if (MessageBox.Show("Would you like to replace the combat style on the list?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {                          
                            CombatStyles.Remove(styleCompare);
                        }
                        else
                            OK = false;
                    }
                }

                if (OK)
                {
                    CombatStyles.Add(style);
                    CombatStyles_List.DataSource = new List<CombatStyle>(CombatStyles);
                }
            }
      
        }

        private void LoadCombatStyle_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog LoadDialog = new OpenFileDialog();
            LoadDialog.ShowDialog();
            using (
            FileStream FileIn = (FileStream)LoadDialog.OpenFile())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<CombatStyle>));

                CombatStyles = (List<CombatStyle>)ser.ReadObject(FileIn);
                CombatStyles_List.DataSource = CombatStyles;
            }
        }

        private void LoadCombatStyle_Click(object sender, EventArgs e)
        {
            if (CombatStyles_List.SelectedItem != null)
            {
                CombatStyle inCom = new CombatStyle((CombatStyle)CombatStyles_List.SelectedItem);
                CombatStyleNameIn_Text.Text = inCom.Name;

                CombatStyleComAttrFireIn_Num.Value = inCom.Attributes.elements.Fire;
                CombatStyleComAttrAirIn_Num.Value = inCom.Attributes.elements.Air;
                CombatStyleComAttrEarthIn_Num.Value = inCom.Attributes.elements.Earth;
                CombatStyleComAttrIceIn_Num.Value = inCom.Attributes.elements.Ice;

                CombatStyleComAttrSlashIn_Num.Value = inCom.Attributes.normal.Slashing;
                CombatStyleComAttrBashIn_Num.Value = inCom.Attributes.normal.Bashing;
                CombatStyleComAttrPierceIn_Num.Value = inCom.Attributes.normal.Piercing;

                CombatStylePClassIn_Text.Text = inCom.PartialClassLocation;
                CombatStyleAnimIn_Text.Text = inCom.Animation;
            }
        }

        private void CombatStyleComAttrFireIn_Num_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CombatStyleAnimation_Button_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog anime = new OpenFileDialog();

            if (anime.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CombatStyleAnimIn_Text.Text = anime.FileName;
            }
        }

        private void CombatStlePClass_Button_Click(object sender, EventArgs e)
        {
            OpenFileDialog PClass = new OpenFileDialog();

            if (PClass.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                CombatStylePClassIn_Text.Text = PClass.FileName;
            }
        }

        private void DeleteCombateStyle_Button_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Are you sure you want to remove this combat style?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                System.Console.Write("\n\nHit\n\n");
                CombatStyles.Remove((CombatStyle)CombatStyles_List.SelectedItem);
                CombatStyles_List.DataSource = new List<CombatStyle>(CombatStyles);
            }
        
        }

        private void CombatStyleDialogSaveAs()
        {
                SaveFileDialog SaveDialog = new SaveFileDialog();
                SaveDialog.ShowDialog();
                 if (SaveDialog.FileName != "")
                    saveStream = (FileStream) SaveDialog.OpenFile();
                 
                 else
                    return;
                
         }         

        public void CombatStyleSave()
        {
            
            if(saveStream==null)
                CombatStyleDialogSaveAs();
                
            else 
            {
                 CombatAttributes Attri = new CombatAttributes(CombatStyleComAttrFireIn_Num.Value, CombatStyleComAttrIceIn_Num.Value, CombatStyleComAttrAirIn_Num.Value, CombatStyleComAttrEarthIn_Num.Value, CombatStyleComAttrSlashIn_Num.Value, CombatStyleComAttrBashIn_Num.Value, CombatStyleComAttrPierceIn_Num.Value);
               
                String Name = CombatStyleNameIn_Text.Text;
                String pFileLocation = CombatStylePClassIn_Text.Text;
                String animeFileLocation = CombatStyleAnimIn_Text.Text;

                CombatStyle style = new CombatStyle(Attri, Name ,pFileLocation, animeFileLocation);
                
                if (!CombatStyles.Contains(style))
                {
                    CombatStyles.Add(style);
                }
                
                
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<CombatStyle>));
                serializer.WriteObject(saveStream, CombatStyles);
              
            } 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CombatStyleSave();
        }

        private void ItemSave_Button_Click(object sender, EventArgs e)
        {
            if(ItemNameIn_Text.Text!="")
            {
                 if(ItemTypeIn_Drop.Text=="Weapon")
                 {
                        CombatAttributes newWepCom = new CombatAttributes(
                                         WeapComAttrFireIn_Num.Value,
                                         WeapComAttrIceIn_Num.Value,
                                         WeapComAttrAirIn_Num.Value,
                                         WeapComAttrEarthIn_Num.Value,
                                         WeapComAttrSlashIn_Num.Value,
                                         WeapComAttrBashIn_Num.Value,
                                         WeapComAttrPierceIn_Num.Value);

                        Weapon newWep = new Weapon(newWepCom, WeaponCombatStyles);
                 }
                 else if(ItemTypeIn_Drop.Text=="Armor")
                 {


                 }
                 else if (ItemTypeIn_Drop.Text == "Item")
                 {
                 }
                 else
                 { }
            }
        }
       
       
    }
}
