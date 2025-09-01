using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OzayPlise.Classes.Other;

namespace OzayPlise
{
    public static class DatabaseHelper
    {
        public static string GetConnectionString()
        {
           return "a"
        }

        public static string GetSetting(string settingsName)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT value FROM setting WHERE settings_name = @settingsName";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@settingsName", settingsName);
                    var result = command.ExecuteScalar();
                    return result?.ToString();
                }
            }
        }

        public static List<Ayarlar> GetSettingsList(string settingsName)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM setting WHERE settings_name LIKE @settingsName";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@settingsName", settingsName + "%");
                    using (var reader = command.ExecuteReader())
                    {
                        var ayarlar = new List<Ayarlar>();
                        while (reader.Read())
                        {
                            var ayar = new Ayarlar
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                SettingsName = reader["settings_name"].ToString(),
                                Title = reader["title"].ToString(),
                                Value = reader["value"].ToString()
                            };
                            ayarlar.Add(ayar);
                        }
                        return ayarlar;
                    }
                }
            }
        }

        public static List<Malzeme> GetAllMalzemeler()
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM malzeme";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        var malzemeler = new List<Malzeme>();
                        while (reader.Read())
                        {
                            var malzeme = new Malzeme
                            {
                                Id = Convert.ToInt32(reader["id"].ToString()),
                                Product = reader["product"].ToString(),
                                Type = reader["type"].ToString(),
                                Price = Convert.ToDouble(reader["price"].ToString()),
                                PriceString = reader["price"].ToString().Replace(",", ".")
                            };
                            malzemeler.Add(malzeme);
                        }
                        return malzemeler;
                    }
                }

            }
        }
        public static void UpdateMalzeme(int id, string value)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string updateQuery = "UPDATE malzeme SET price = @price WHERE id = @id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@price", value.Replace(",", "."));
                    if (command.ExecuteNonQuery() != -1)
                    {
                        MessageBox.Show("Güncelleme başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        public static void UpdateSettings(int id, string value)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string updateQuery = "UPDATE setting SET value = @value WHERE id = @id";
                using (var command = new SQLiteCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@value", value);
                    if (command.ExecuteNonQuery() != -1)
                    {
                        MessageBox.Show("Güncelleme başarılı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Güncelleme başarısız.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        public static Malzeme GetMalzeme(int id)
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT product, price FROM malzeme WHERE id = @id";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Malzeme
                            {
                                Product = reader["product"].ToString(),
                                Price = Convert.ToDouble(reader["price"].ToString().Replace(".", ","))
                            };
                        }
                    }
                }
            }
            return null;
        }

        public static DataTable GetAllTur(string kalinlik = "18mm")
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM t  WHERE kalinlik = @k";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    command.Parameters.AddWithValue("@k", kalinlik);
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable GetAllSineklik()
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM sinek";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {
                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

        public static DataTable GetAllKalinlik()
        {
            using (var connection = new SQLiteConnection(GetConnectionString()))
            {
                connection.Open();
                string selectQuery = "SELECT * FROM kalin";
                using (var command = new SQLiteCommand(selectQuery, connection))
                {

                    using (var adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        return dataTable;
                    }
                }
            }
        }

    }
}
