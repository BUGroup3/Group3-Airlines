﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Database;
using WindowsFormsApp1.Controls.Database.DbConnect;
using System.Data;
using System.Data.SqlClient;

namespace WindowsFormsApp1.Controls.Database.DbConnect
{
    class SirketlerProvider

    {
        SqlDataReader reader;
        DbConnector dbcon = new DbConnector();
        public SirketlerProvider()
        {
            dbcon.Baglan();

        }
        public List<Sirketler> Listele()
        {

            try
            {
                List<Sirketler> SirketlerListesi = new List<Sirketler>();
                dbcon.cmd.CommandText = "Select *From Sirketler";
                dbcon.cmd.CommandType = CommandType.Text;
                dbcon.con.Open();
                SqlDataReader reader = dbcon.cmd.ExecuteReader();
                while (reader.Read())
                {
                    Sirketler s = new Sirketler();
                    s.SirketID = Convert.ToInt32(reader[0].ToString());
                    s.SirketAdi = reader[1].ToString();

                    SirketlerListesi.Add(s);
                }

                return SirketlerListesi;
            }
            catch
            {
                throw;
            }
            finally
            {
                if (dbcon.con != null)
                {
                    dbcon.con.Close();
                }
            }
        }
        public int GetID(string SirketAdi)
        {
            int ID;
            try
            {

                dbcon.cmd = new SqlCommand("SELECT SirketID FROM [Sirketler] where SirketAdi=@SirketAdi", dbcon.con);
                dbcon.cmd.Parameters.AddWithValue("@SirketAdi", SirketAdi);
                dbcon.con.Open();
                reader = dbcon.cmd.ExecuteReader();
                reader.Read();
                ID = Convert.ToInt32(reader["SirketID"]);
                return ID;




            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (dbcon.con != null)
                {
                    dbcon.con.Close();
                }
            }
        }
        public void Ekle(string SirketAdi)
        {
            try
            {
                dbcon.cmd.CommandText = "Insert Into Sirketler (SirketAdi) Values (" + SirketAdi + "')";
                dbcon.cmd.CommandType = CommandType.Text;
                dbcon.con.Open();
                dbcon.cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (dbcon.con != null)
                {
                    dbcon.con.Close();
                }
            }

        }

        public void Guncelle(Sirketler sirket, string SirketAdi)
        {
            try
            {
                dbcon.cmd.CommandText = "Update Sirketler SET SirketAdi='" + SirketAdi + "' Where SirketID=" + sirket.SirketAdi + "";
                dbcon.cmd.CommandType = CommandType.Text;
                dbcon.con.Open();
                dbcon.cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (dbcon.con != null)
                {
                    dbcon.con.Close();
                }
            }

        }

        public void Sil(Sirketler s)
        {
            try
            {
                dbcon.cmd.CommandText = "Delete From Sirketler Where SirketID=" + s.SirketID + "";
                dbcon.cmd.CommandType = CommandType.Text;
                dbcon.con.Open();
                dbcon.cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (dbcon.con != null)
                {
                    dbcon.con.Close();
                }
            }

        }
        public void ListOfSirketler(Guna.UI2.WinForms.Guna2ComboBox cmbSirketler)
        {
            try
            {

                dbcon.cmd = new SqlCommand("SELECT * FROM [Sirketler]", dbcon.con);
                dbcon.con.Open();
                reader = dbcon.cmd.ExecuteReader();


                while (reader.Read())
                {

                    cmbSirketler.Items.Add(reader["SirketAdi"]);

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (dbcon.con != null)
                {
                    dbcon.con.Close();
                }
            }
        }
    }
}
