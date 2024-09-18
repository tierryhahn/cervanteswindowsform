using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace CervantesWindowsForm
{
    public partial class Form1 : Form
    {
        private string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["PostgresConnection"].ConnectionString;
        private int? selectedId = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("SELECT id, campo_texto, campo_numerico FROM cadastro", connection);
                var adapter = new NpgsqlDataAdapter(command);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                dataGridView.DataSource = dataTable;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var textField = txtFieldText.Text;
            if (int.TryParse(txtFieldNumeric.Text, out var numericField))
            {
                if (string.IsNullOrWhiteSpace(textField))
                {
                    MessageBox.Show("Campo texto não pode estar vazio.");
                    return;
                }

                if (numericField == 0)
                {
                    MessageBox.Show("O campo numérico não pode ser 0.");
                    return;
                }

                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Verifica se o número já existe
                            var checkCommand = new NpgsqlCommand("SELECT COUNT(1) FROM cadastro WHERE campo_numerico=@numericField", connection);
                            checkCommand.Parameters.AddWithValue("numericField", numericField);
                            var exists = (long)checkCommand.ExecuteScalar() > 0;

                            if (exists)
                            {
                                MessageBox.Show("O valor numérico já está registrado.");
                                return;
                            }

                            if (selectedId == null)
                            {
                                var command = new NpgsqlCommand("INSERT INTO cadastro (campo_texto, campo_numerico) VALUES (@textField, @numericField) RETURNING id", connection);
                                command.Parameters.AddWithValue("textField", textField);
                                command.Parameters.AddWithValue("numericField", numericField);
                                var idObject = command.ExecuteScalar();
                                if (idObject is int id)
                                {
                                    var logCommand = new NpgsqlCommand("INSERT INTO log_operacoes (tipo_operacao, cadastro_id) VALUES ('Insert', @id)", connection);
                                    logCommand.Parameters.AddWithValue("id", id);
                                    logCommand.ExecuteNonQuery();
                                }
                            }
                            else
                            {
                                var command = new NpgsqlCommand("UPDATE cadastro SET campo_texto=@textField, campo_numerico=@numericField WHERE id=@id", connection);
                                command.Parameters.AddWithValue("textField", textField);
                                command.Parameters.AddWithValue("numericField", numericField);
                                command.Parameters.AddWithValue("id", selectedId.Value);
                                command.ExecuteNonQuery();

                                var logCommand = new NpgsqlCommand("INSERT INTO log_operacoes (tipo_operacao, cadastro_id) VALUES ('Update', @id)", connection);
                                logCommand.Parameters.AddWithValue("id", selectedId.Value);
                                logCommand.ExecuteNonQuery();
                            }

                            transaction.Commit();
                            LoadData();
                            ClearInputs();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao salvar dados: {ex.Message}");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Insira um valor numérico válido.");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (selectedId != null)
            {
                var textField = txtFieldText.Text;
                if (int.TryParse(txtFieldNumeric.Text, out var numericField))
                {
                    if (string.IsNullOrWhiteSpace(textField))
                    {
                        MessageBox.Show("Campo texto não pode estar vazio.");
                        return;
                    }

                    if (numericField == 0)
                    {
                        MessageBox.Show("O campo numérico não pode ser 0.");
                        return;
                    }

                    using (var connection = new NpgsqlConnection(connectionString))
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            try
                            {
                                var command = new NpgsqlCommand("UPDATE cadastro SET campo_texto=@textField, campo_numerico=@numericField WHERE id=@id", connection);
                                command.Parameters.AddWithValue("textField", textField);
                                command.Parameters.AddWithValue("numericField", numericField);
                                command.Parameters.AddWithValue("id", selectedId.Value);
                                command.ExecuteNonQuery();

                                var logCommand = new NpgsqlCommand("INSERT INTO log_operacoes (tipo_operacao, cadastro_id) VALUES ('Update', @id)", connection);
                                logCommand.Parameters.AddWithValue("id", selectedId.Value);
                                logCommand.ExecuteNonQuery();

                                transaction.Commit();
                                LoadData();
                                ClearInputs();
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show($"Erro ao atualizar dados: {ex.Message}");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Insira um valor numérico válido.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId != null)
            {
                using (var connection = new NpgsqlConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            var logCommand = new NpgsqlCommand("INSERT INTO log_operacoes (tipo_operacao, cadastro_id) VALUES ('Delete', @id)", connection);
                            logCommand.Parameters.AddWithValue("id", selectedId.Value);
                            logCommand.ExecuteNonQuery();

                            var deleteLogCommand = new NpgsqlCommand("DELETE FROM log_operacoes WHERE cadastro_id=@id", connection);
                            deleteLogCommand.Parameters.AddWithValue("id", selectedId.Value);
                            deleteLogCommand.ExecuteNonQuery();

                            var deleteCommand = new NpgsqlCommand("DELETE FROM cadastro WHERE id=@id", connection);
                            deleteCommand.Parameters.AddWithValue("id", selectedId.Value);
                            deleteCommand.ExecuteNonQuery();

                            transaction.Commit();
                            LoadData();
                            ClearInputs();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Erro ao excluir dados: {ex.Message}");
                        }
                    }
                }
            }
        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView.Rows[e.RowIndex];
                selectedId = Convert.ToInt32(row.Cells["id"].Value);
                txtFieldText.Text = row.Cells["campo_texto"].Value.ToString();
                txtFieldNumeric.Text = row.Cells["campo_numerico"].Value.ToString();
            }
        }

        private void ClearInputs()
        {
            txtFieldText.Clear();
            txtFieldNumeric.Clear();
            selectedId = null;
        }
    }
}