using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EggHunt
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            foreach( Control c in tableLayoutPanel2.Controls ) {
                if( c is CheckBox b ) {
                    b.AutoCheck = false;
                }
            }
            foreach( Control c in tableLayoutPanel3.Controls ) {
                if( c is CheckBox b ) {
                    b.AutoCheck = false;
                }
            }
        }

        private void NumericUpDown1_ValueChanged( object sender, EventArgs e )
        {
            if( textBox1.Text.Length < 3 ) {
                MessageBox.Show( "キャラ名を入力してください。", "(´・ω・｀)", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                textBox1.Select();
                return;
            }

            bool b = true;
            int[] init = new int[] { textBox1.Text.ToUpper()[0] - 'A', textBox1.Text.ToUpper()[1] - 'A', textBox1.Text.ToUpper()[2] - 'A' };
            NumericUpDown[] nud = { numericUpDown1, numericUpDown2, numericUpDown3, numericUpDown4, numericUpDown5,
                numericUpDown6, numericUpDown7, numericUpDown8, numericUpDown9, numericUpDown10,
                numericUpDown11, numericUpDown12, numericUpDown13, numericUpDown14, numericUpDown15,
                numericUpDown16, numericUpDown17, numericUpDown18, numericUpDown19, numericUpDown20,
                numericUpDown21, numericUpDown22, numericUpDown23, numericUpDown24, numericUpDown25, numericUpDown26 };

            checkBox1.Checked = 0 < nud[init[0]].Value && 0 < nud[init[1]].Value && 0 < nud[init[2]].Value;
            foreach( int i in Enumerable.Range( 0, 8 ) ) {
                if( nud[Idx( textBox1.Text.ToUpper()[0] - 'A' + i )].Value == 0 ) {
                    b = false;
                    break;
                }
            }
            checkBox2.Checked = b;
            b = false;
            foreach( NumericUpDown n in nud ) {
                if( 7 <= n.Value ) {
                    b = true;
                    break;
                }
            }
            checkBox3.Checked = b;
            foreach( Control c in tableLayoutPanel2.Controls ) {
                if( c is CheckBox cb ) {
                    cb.Checked = CBText( cb.Text );
                }
            }
            foreach( Control c in tableLayoutPanel3.Controls ) {
                if( c is CheckBox cb ) {
                    cb.Checked = CBText( cb.Text );
                }
            }
            checkBox30.Checked = CBText( checkBox30.Text );
            checkBox31.Checked = CBText( checkBox31.Text );
            checkBox32.Checked = CBText( checkBox32.Text );
            checkBox33.Checked = CBText( "THANKYOU" );
            checkBox34.Checked = CBText( "FES" );
            return;

            int Idx( int i )
            {
                if( 25 < i ) {
                    i -= 26;
                }
                return i;
            }

            bool CBText( string s )
            {
                bool ret = true;
                var dic = new Dictionary<char, int>( s.Length );

                foreach( char c in s ) {
                    if( dic.ContainsKey( c ) != true ) {
                        dic.Add( c, 1 );
                    } else {
                        dic[c]++;
                    }
                }
                foreach( var p in dic ) {
                    if( nud[p.Key - 'A'].Value < p.Value ) {
                        ret = false;
                        break;
                    }
                }
                return ret;
            }
        }
    }
}
