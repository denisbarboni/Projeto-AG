using System;
using System.Collections.Generic;
using Objetos;
using System.Data.SqlClient;

namespace Acesso
{
    public class DAO
    {
        private string strConn;
        //private string server = "127.0.0.1";
        //private string port = "5432";
        //private string user = "algjssp1_botter";
        //private string pass = "algjssp";
        //private string db = "algjssp1_algjssp";

        private SqlConnection conn;

        public DAO()
        {
            //strConn = String.Format("Server={0};Port={1};Userid={2};Password={3};Database={4};", server, port, user, pass, db);
            strConn = "Server=tcp:xd08uqfyjs.database.windows.net,1433;Database=algjssp;User ID=algjssp@xd08uqfyjs;Password=*Ximbalaie3#;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        }

        #region Plano e login
        public Plano GetPlano(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM plano WHERE IdPlano = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    return new Plano()
                    {
                        IdPlano = rd.GetInt32(0),
                        NomePlano = rd.GetString(1),
                        DescricaoPlano = Convert.ToString(rd[2].ToString()),
                        PrecoPlano = Convert.ToDouble(rd[3].ToString())
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Login verificarLogin(Login l)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM usuario WHERE Login = @login and SENHA = @senha";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@login", l.User);
                cmd.Parameters.AddWithValue("@senha", l.Senha);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    return new Login()
                    {
                        IdLogin = rd.GetInt32(0),
                        User = rd.GetString(1),
                        Senha = rd.GetString(2),
                        Plano = GetPlano(rd.GetInt32(3))
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Config
        public Configuracao GetConfig(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM Configuracao WHERE IdUser = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    return new Configuracao()
                    {
                        IdConfig = rd.GetInt32(0),
                        SolucaoMax = Convert.ToDouble(rd[1].ToString()),
                        TaxaCrossover = Convert.ToDouble(rd[2].ToString()),
                        TaxaMutacao = Convert.ToDouble(rd[3].ToString()),
                        Eltismo = Convert.ToBoolean(rd[4].ToString()),
                        TotalPopulacao = Convert.ToInt32(rd[5].ToString()),
                        TotalGeracao = Convert.ToInt32(rd[6].ToString())
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddConfig(Configuracao cfg)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "INSERT INTO configuracao VALUES (@SolucaoMax, @TaxaCrossover, @TaxaMutacao, true, @TotalPopulacao, @totalGeracao);";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@id", cfg.IdConfig);
                cmd.Parameters.AddWithValue("@SolucaoMax", cfg.SolucaoMax);
                cmd.Parameters.AddWithValue("@TaxaCrossover", cfg.TaxaCrossover);
                cmd.Parameters.AddWithValue("@TaxaMutacao", cfg.TaxaMutacao);
                //cmd.Parameters.AddWithValue("@Eltimo", true);
                cmd.Parameters.AddWithValue("@TotalPopulacao", cfg.TotalPopulacao);
                cmd.Parameters.AddWithValue("@TotalGeracao", cfg.TotalGeracao);

                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean EdtConfig(Configuracao cfg)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "UPDATE configuracao SET SolucaoMax = @SolucaoMax, TaxaCrossover = @TaxaCrossover, TaxaMutacao = @TaxaMutacao, TotalPopulacao = @TotalPopulacao, TotalGeracao = @TotalGeracao WHERE IdUser = @id";

                SqlCommand cmd = new SqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@SolucaoMax", cfg.SolucaoMax);
                cmd.Parameters.AddWithValue("@TaxaCrossover", Convert.ToDouble(cfg.TaxaCrossover));
                cmd.Parameters.AddWithValue("@TaxaMutacao", Convert.ToDouble(cfg.TaxaMutacao));
                //cmd.Parameters.AddWithValue("@Eltimo", true);
                cmd.Parameters.AddWithValue("@TotalPopulacao", cfg.TotalPopulacao);
                cmd.Parameters.AddWithValue("@TotalGeracao", cfg.TotalGeracao);
                cmd.Parameters.AddWithValue("@id", cfg.IdConfig);

                return Convert.ToBoolean(cmd.ExecuteNonQuery());
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region pegaProximoId
        public int PegarProximoId(string tbl)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "select IDENT_CURRENT('" + tbl + "') + 1";

                SqlCommand cmd = new SqlCommand(query, conn);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    return Convert.ToInt32(rd[0].ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Maquina
        public List<Maquina> GetMaq(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM maquina WHERE idUser = @idUser";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader rd = cmd.ExecuteReader();

                List<Maquina> lstMaq = new List<Maquina>();

                while (rd.Read())
                {
                    lstMaq.Add(new Maquina()
                    {
                        Id_Maquina = Convert.ToInt32(rd[0].ToString()),
                        Descricao = rd[1].ToString(),
                        idUser = Convert.ToInt32(rd[2].ToString())
                    });
                }

                return lstMaq;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean VerificaExistenciaMaq(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM maquina WHERE id_maquina = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) return true; else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddEdtMaq(Maquina maq)
        {
            try
            {
                if (VerificaExistenciaMaq(maq.Id_Maquina))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "UPDATE maquina SET nome = @nome WHERE id_maquina = @id and iduser = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", maq.Descricao);
                    cmd.Parameters.AddWithValue("@id", maq.Id_Maquina);
                    cmd.Parameters.AddWithValue("@user", maq.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                else
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "INSERT INTO maquina VALUES (@id, @nome, @user);";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", maq.Id_Maquina);
                    cmd.Parameters.AddWithValue("@nome", maq.Descricao);
                    cmd.Parameters.AddWithValue("@user", maq.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Int32 RemMaq(int id)
        {
            try
            {
                if (VerificaExistenciaMaq(id))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "DELETE FROM maquina WHERE id_maquina = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Setor
        public List<Setor> GetSetor(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM Setor WHERE idUser = @idUser";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader rd = cmd.ExecuteReader();

                List<Setor> lstSetor = new List<Setor>();

                while (rd.Read())
                {
                    lstSetor.Add(new Setor()
                    {
                        Id_Setor = Convert.ToInt32(rd[0].ToString()),
                        Descricao = rd[1].ToString(),
                        idUser = Convert.ToInt32(rd[2].ToString())
                    });
                }

                return lstSetor;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean VerificaExistenciaSetor(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM setor WHERE id_setor = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) return true; else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddEdtSetor(Setor setor)
        {
            try
            {
                if (VerificaExistenciaSetor(setor.Id_Setor))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "UPDATE setor SET nome = @nome WHERE id_setor = @id and iduser = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", setor.Descricao);
                    cmd.Parameters.AddWithValue("@id", setor.Id_Setor);
                    cmd.Parameters.AddWithValue("@user", setor.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                else
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "INSERT INTO setor VALUES (@nome, @user);";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", setor.Id_Setor);
                    cmd.Parameters.AddWithValue("@nome", setor.Descricao);
                    cmd.Parameters.AddWithValue("@user", setor.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Int32 RemSetor(int id)
        {
            try
            {
                if (VerificaExistenciaSetor(id))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "DELETE FROM setor WHERE id_setor = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Sku
        public List<Sku> GetSku(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM Sku WHERE idUser = @idUser ORDER BY nome_sku";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader rd = cmd.ExecuteReader();

                List<Sku> lstSku = new List<Sku>();

                while (rd.Read())
                {
                    lstSku.Add(new Sku()
                    {
                        Id_Sku = Convert.ToInt32(rd[0].ToString()),
                        Descricao = rd[1].ToString(),
                        Peso_Caixa = Convert.ToDouble(rd[2].ToString()),
                        idUser = Convert.ToInt32(rd[3].ToString())
                    });
                }

                return lstSku;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean VerificaExistenciaSku(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM sku WHERE id_sku = @id ORDER BY nome_sku";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) return true; else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddEdtSku(Sku sku)
        {
            try
            {
                if (VerificaExistenciaSku(sku.Id_Sku))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "UPDATE sku SET nome_sku = @nome_sku, peso_caixa = @peso WHERE id_sku = @id_sku and iduser = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome_sku", sku.Descricao);
                    cmd.Parameters.AddWithValue("@id_sku", sku.Id_Sku);
                    cmd.Parameters.AddWithValue("@peso", sku.Peso_Caixa);
                    cmd.Parameters.AddWithValue("@user", sku.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                else
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "INSERT INTO sku VALUES (@nome, @peso, @user);";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", sku.Id_Sku);
                    cmd.Parameters.AddWithValue("@nome", sku.Descricao);
                    cmd.Parameters.AddWithValue("@user", sku.idUser);
                    cmd.Parameters.AddWithValue("@peso", sku.Peso_Caixa);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Int32 RemSku(int id)
        {
            try
            {
                if (VerificaExistenciaSku(id))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "DELETE FROM sku WHERE id_sku = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Unidade
        public List<Unidade> GetUnidade(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM unidade WHERE idUser = @idUser ORDER BY nome";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader rd = cmd.ExecuteReader();

                List<Unidade> lstMaq = new List<Unidade>();

                while (rd.Read())
                {
                    lstMaq.Add(new Unidade()
                    {
                        Codigo_Un = rd[0].ToString(),
                        Descricao = rd[1].ToString(),
                        idUser = Convert.ToInt32(rd[2].ToString())
                    });
                }

                return lstMaq;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean VerificaExistenciaUnidade(string cod, int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM unidade WHERE codigo = @cod and iduser = @id ORDER BY nome";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@cod", cod);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) return true; else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddEdtUnidade(Unidade un)
        {
            try
            {
                if (VerificaExistenciaUnidade(un.Codigo_Un, un.idUser))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "UPDATE unidade SET nome = @nome WHERE codigo = @cod and iduser = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@nome", un.Descricao);
                    cmd.Parameters.AddWithValue("@cod", un.Codigo_Un);
                    cmd.Parameters.AddWithValue("@user", un.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                else
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "INSERT INTO unidade VALUES (@cod, @nome, @user);";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cod", un.Codigo_Un);
                    cmd.Parameters.AddWithValue("@nome", un.Descricao);
                    cmd.Parameters.AddWithValue("@user", un.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Int32 RemUnidade(string cod, int idUser)
        {
            try
            {
                if (VerificaExistenciaUnidade(cod, idUser))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "DELETE FROM unidade WHERE codigo = @cod and iduser = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@cod", cod);
                    cmd.Parameters.AddWithValue("@id", idUser);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Job
        public List<Job> GetJob(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM job WHERE idUser = @idUser ORDER BY id_sku";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader rd = cmd.ExecuteReader();

                List<Job> lstJob = new List<Job>();

                while (rd.Read())
                {
                    lstJob.Add(new Job()
                    {
                        Id_Job = Convert.ToInt32(rd[0].ToString()),
                        Sku = new Sku()
                        {
                            Id_Sku = Convert.ToInt32(rd[1].ToString())
                        },
                        Qtde = Convert.ToDouble(rd[2].ToString()),
                        idUser = Convert.ToInt32(rd[3].ToString())
                    });
                }

                return lstJob;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean VerificaExistenciaJob(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM job WHERE id_job = @id ORDER BY id_sku";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) return true; else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddEdtJob(Job job)
        {
            try
            {
                if (VerificaExistenciaJob(job.Id_Job))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "UPDATE job SET id_sku = @id_sku, quantidade = @qtde WHERE id_job = @id_job and iduser = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_sku", job.Sku.Id_Sku);
                    cmd.Parameters.AddWithValue("@qtde", job.Qtde);
                    cmd.Parameters.AddWithValue("@id_job", job.Id_Job);
                    cmd.Parameters.AddWithValue("@user", job.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                else
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "INSERT INTO job VALUES (@id_sku, @qtde, @user);";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_sku", job.Sku.Id_Sku);
                    cmd.Parameters.AddWithValue("@qtde", job.Qtde);
                    cmd.Parameters.AddWithValue("@id_job", job.Id_Job);
                    cmd.Parameters.AddWithValue("@user", job.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Int32 RemJob(int id)
        {
            try
            {
                if (VerificaExistenciaJob(id))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "DELETE FROM job WHERE id_job = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Job
        public List<Velocidade> GetVel(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM velocidade WHERE idUser = @idUser";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idUser", idUser);

                SqlDataReader rd = cmd.ExecuteReader();

                List<Velocidade> lstVel = new List<Velocidade>();

                while (rd.Read())
                {
                    lstVel.Add(new Velocidade()
                    {
                        Id_Velocidade = Convert.ToInt32(rd[0].ToString()),
                        Setor = new Setor() { Id_Setor = Convert.ToInt32(rd[1].ToString()) },
                        Maquina = new Maquina() { Id_Maquina = Convert.ToInt32(rd[2].ToString()) },
                        Sku = new Sku() { Id_Sku = Convert.ToInt32(rd[3].ToString()) },
                        Velocidade_Hr = Convert.ToDouble(rd[4].ToString()),
                        idUser = Convert.ToInt32(rd[5].ToString())
                    });
                }

                return lstVel;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean VerificaExistenciaVelocidade(int id)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM velocidade WHERE id_velocidade = @id";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read()) return true; else return false;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Boolean AddEdtVel(Velocidade vel)
        {
            try
            {
                if (VerificaExistenciaVelocidade(vel.Id_Velocidade))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "UPDATE velocidade SET id_maquina = @id_maq, id_setor = @id_setor, id_sku = @id_sku, velocidade_hora = @vel_hr WHERE id_velocidade = @id_velocidade and iduser = @user";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_sku", vel.Sku.Id_Sku);
                    cmd.Parameters.AddWithValue("@id_maq", vel.Maquina.Id_Maquina);
                    cmd.Parameters.AddWithValue("@id_setor", vel.Setor.Id_Setor);
                    cmd.Parameters.AddWithValue("@vel_hr", vel.Velocidade_Hr);
                    cmd.Parameters.AddWithValue("@user", vel.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
                else
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "INSERT INTO velocidade VALUES (@id_setor, @id_maq, @id_sku, @vel_hr, @user);";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id_vel", vel.Id_Velocidade);
                    cmd.Parameters.AddWithValue("@id_sku", vel.Sku.Id_Sku);
                    cmd.Parameters.AddWithValue("@id_maq", vel.Maquina.Id_Maquina);
                    cmd.Parameters.AddWithValue("@id_setor", vel.Setor.Id_Setor);
                    cmd.Parameters.AddWithValue("@vel_hr", vel.Velocidade_Hr);
                    cmd.Parameters.AddWithValue("@user", vel.idUser);

                    return Convert.ToBoolean(cmd.ExecuteNonQuery());
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        public Int32 RemVel(int id)
        {
            try
            {
                if (VerificaExistenciaVelocidade(id))
                {
                    conn = new SqlConnection(strConn);
                    conn.Open();

                    var query = "DELETE FROM velocidade WHERE id_velocidade = @id";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@id", id);

                    return cmd.ExecuteNonQuery();
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region AlterarSenha
        public int AlterarSenha(AlterarSenha altSenha)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT * FROM usuario WHERE IdUsuario = @id and Senha = @senha";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", altSenha.idUser);
                cmd.Parameters.AddWithValue("@senha", altSenha.Senha);

                SqlDataReader rd = cmd.ExecuteReader();

                bool ok = false;

                if (rd.Read()) ok = true;

                rd.Close();

                if (ok)
                {
                    if (altSenha.SenhaNova.Equals(altSenha.SenhaNova2) && altSenha.SenhaNova != "" && altSenha.SenhaNova2 != "")
                    {
                        query = "UPDATE usuario SET senha = @senha WHERE idUsuario = @id";

                        cmd = new SqlCommand(query, conn);
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@senha", altSenha.SenhaNova);
                        cmd.Parameters.AddWithValue("@id", altSenha.idUser);

                        return cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion

        #region Algoritimo
        public List<VelMaqJobsSku> returnVelMaqJobsSku(int idUser)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "select * from velocidade v join maquina m on m.id_maquina = v.id_maquina join job j on v.id_sku = j.id_sku join sku s on s.id_sku = v.id_sku where v.iduser = @id and m.iduser = @id and j.iduser = @id and s.iduser = @id order by m.nome, s.nome_sku";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", idUser);

                SqlDataReader rd = cmd.ExecuteReader();
                List<VelMaqJobsSku> lstVelMaqJobsSku = new List<VelMaqJobsSku>();

                while (rd.Read())
                {
                    lstVelMaqJobsSku.Add(new VelMaqJobsSku()
                    {
                        Vel = new Velocidade()
                        {
                            Id_Velocidade = Convert.ToInt32(rd[0].ToString()),
                            Setor = new Setor() { Id_Setor = Convert.ToInt32(rd[1].ToString()) },
                            Maquina = new Maquina() { Id_Maquina = Convert.ToInt32(rd[2].ToString()) },
                            Sku = new Sku() { Id_Sku = Convert.ToInt32(rd[3].ToString()) },
                            Velocidade_Hr = Convert.ToDouble(rd[4].ToString()),
                            idUser = Convert.ToInt32(rd[5].ToString())
                        },
                        Maq = new Maquina()
                        {
                            Id_Maquina = Convert.ToInt32(rd[6].ToString()),
                            Descricao = rd[7].ToString(),
                            idUser = Convert.ToInt32(rd[8].ToString())
                        },
                        Job = new Job()
                        {
                            Id_Job = Convert.ToInt32(rd[9].ToString()),
                            Sku = new Sku() { Id_Sku = Convert.ToInt32(rd[10].ToString()) },
                            Qtde = Convert.ToDouble(rd[11].ToString()),
                            idUser = Convert.ToInt32(rd[12].ToString())
                        },
                        Sku = new Sku()
                        {
                            Id_Sku = Convert.ToInt32(rd[13].ToString()),
                            Descricao = rd[14].ToString(),
                            Peso_Caixa = Convert.ToDouble(rd[15].ToString()),
                            idUser = Convert.ToInt32(rd[16].ToString())
                        }
                    });
                }

                return lstVelMaqJobsSku;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }

        //retorna o valor do gene gerado
        public double getValorGene(string dSku, string dMaq)
        {
            try
            {
                conn = new SqlConnection(strConn);
                conn.Open();

                var query = "SELECT sku.peso_caixa * quantidade * velocidade_hora FROM maquina, sku, job, velocidade WHERE maquina.id_maquina = velocidade.id_maquina and sku.id_sku = velocidade.id_sku and job.id_sku = sku.id_sku and sku.nome_sku = @dsku and maquina.nome = @dmaq";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@dsku", dSku);
                cmd.Parameters.AddWithValue("@dmaq", dMaq);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                    return Convert.ToDouble(rd[0].ToString());
                else
                    return 0;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion
    }
}
