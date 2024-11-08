using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;

using System.Collections.Generic;

namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_VERBETE
	{

		#region "Variaveis" 

			private  int _VERBETE = -1;
			private  String _NOME = String.Empty;
			private  String _NOMEORDENACAO = String.Empty;
			private  DateTime _DATACRIACAO = new DateTime();
			private  DateTime _DATAALTERACAO = new DateTime();
			private  DateTime _DATAINCLUSAO = new DateTime();


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_VERBETE()
		{
		}
		public rul_VERBETE( int par_VERBETE)
		{
			try
				{
					this.VERBETE = par_VERBETE;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int VERBETE
			{
				get {return _VERBETE;}
				set {_VERBETE = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
			}

			public  String NOMEORDENACAO
			{
				get {return _NOMEORDENACAO;}
				set {_NOMEORDENACAO = value;}
			}

			public  DateTime DATACRIACAO
			{
				get {return _DATACRIACAO;}
				set {_DATACRIACAO = value;}
			}

			public  DateTime DATAALTERACAO
			{
				get {return _DATAALTERACAO;}
				set {_DATAALTERACAO = value;}
			}

			public  DateTime DATAINCLUSAO
			{
				get {return _DATAINCLUSAO;}
				set {_DATAINCLUSAO = value;}
			}





			public String mensagem
			{
				get { return _mensagem; }
				set { _mensagem = value; }
			}
	
			public Boolean NovoRegistro
			{
				get { return _NovoRegistro; }
				set { _NovoRegistro = value;  }
			}

		#endregion

		#region "Metodos Publicos" 

		public Boolean ValidateInsert()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETE VERBETE = new cls_VERBETE();
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

				this.mensagem="";

				Boolean retorno = VERBETE.Insert();

				this.mensagem = VERBETE.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateUpdate()
		{
			try
			{
				// Validacao para o insert e o update
				if (! Validate())
					return false;
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETE VERBETE = new cls_VERBETE();
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

				this.mensagem= "";
				
				Boolean retorno = VERBETE.Update();

				this.mensagem = VERBETE.mensagem;

				return retorno;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean Validate()
		{
			try
			{

				if (  this.NOME == String.Empty)
				{
					this.mensagem = "O Campo NOME tem que ser preenchido com Texto";
					return false;
				}
				if (  this.NOMEORDENACAO == String.Empty)
				{
					this.mensagem = "O Campo NOMEORDENACAO tem que ser preenchido com Texto";
					return false;
				}
				if (  this.DATACRIACAO == new DateTime())
				{
					this.mensagem = "O Campo DATACRIACAO tem que ser preenchido com Data";
					return false;
				}
				if (  this.DATAALTERACAO == new DateTime())
				{
					this.mensagem = "O Campo DATAALTERACAO tem que ser preenchido com Data";
					return false;
				}
				if (  this.DATAINCLUSAO == new DateTime())
				{
					this.mensagem = "O Campo DATAINCLUSAO tem que ser preenchido com Data";
					return false;
				}


				return true;
			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDelete()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETE VERBETE = new cls_VERBETE();

				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = VERBETE.Delete();

						this.mensagem = VERBETE.mensagem;

						return retorno;
					}	
				else
					{
						return false;
					}

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public Boolean ValidateDeleteMasterDetail()
		{
			try
			{
				
				//
				// TODO: Adicionar regras de validacao aqui
				//
				cls_VERBETE VERBETE = new cls_VERBETE();
				

				this.mensagem= "";
				
				Boolean retorno = VERBETE.DeleteMasterDetail();

				this.mensagem = VERBETE.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_VERBETE GetAll()
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();
				col_VERBETE colecao = new col_VERBETE();
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

				System.Data.DataSet ds = VERBETE.GetAll();

                		if (VERBETE.mensagem != String.Empty)
		                {
		                    this.mensagem = VERBETE.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_VERBETE item = new rul_VERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.NOMEORDENACAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.DATACRIACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[3]);

					if( ds.Tables[0].Rows[i].ItemArray[4].ToString() != String.Empty)
						item.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);

					if( ds.Tables[0].Rows[i].ItemArray[5].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[5]);


					item.NovoRegistro = false;
					colecao.Add(item);
				}
				
				return colecao;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllInDataSet()
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();			
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

				System.Data.DataSet ds = VERBETE.GetAll();

				this.mensagem = VERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_VERBETE FindAll()
		{

			cls_VERBETE VERBETE = new cls_VERBETE();
			col_VERBETE colecao = new col_VERBETE();
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

			System.Data.DataSet ds = VERBETE.FindAll();

               		if (VERBETE.mensagem != String.Empty)
	                {
	                    this.mensagem = VERBETE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_VERBETE item = new rul_VERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.NOMEORDENACAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.DATACRIACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[3]);

					if( ds.Tables[0].Rows[i].ItemArray[4].ToString() != String.Empty)
						item.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);

					if( ds.Tables[0].Rows[i].ItemArray[5].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[5]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public col_VERBETE FindAllGrid()
		{

			cls_VERBETE VERBETE = new cls_VERBETE();
			col_VERBETE colecao = new col_VERBETE();
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

			System.Data.DataSet ds = VERBETE.FindAllGrid();

               		if (VERBETE.mensagem != String.Empty)
	                {
	                    this.mensagem = VERBETE.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_VERBETE item = new rul_VERBETE();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.NOMEORDENACAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[3].ToString() != String.Empty)
						item.DATACRIACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[3]);

					if( ds.Tables[0].Rows[i].ItemArray[4].ToString() != String.Empty)
						item.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[4]);

					if( ds.Tables[0].Rows[i].ItemArray[5].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[5]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();			
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

				System.Data.DataSet ds = VERBETE.FindAll();

				this.mensagem = VERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public System.Data.DataSet GetAllMasterDetail()
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();			
				

				System.Data.DataSet ds = VERBETE.GetAllMasterDetail();

				this.mensagem = VERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public Boolean Load()
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();


				
				VERBETE.VERBETE = this.VERBETE;


				System.Data.DataSet ds = VERBETE.Load();


                		if (VERBETE.mensagem != String.Empty)
		                {
		                    this.mensagem = VERBETE.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.VERBETE = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.NOME = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.NOMEORDENACAO = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);

					if( ds.Tables[0].Rows[0].ItemArray[3].ToString() != String.Empty)
						this.DATACRIACAO = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[3]);

					if( ds.Tables[0].Rows[0].ItemArray[4].ToString() != String.Empty)
						this.DATAALTERACAO = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[4]);

					if( ds.Tables[0].Rows[0].ItemArray[5].ToString() != String.Empty)
						this.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[5]);


					this.NovoRegistro = false;
					return true;
				}
				else
				{
					this.mensagem = "Load retornou mais de uma linha";
					this.NovoRegistro = true;
					return false;
				}

			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return false;
			}
		}

		#endregion

		#region "Metodos Privados"

		private Boolean VerifyForeignKeys()
		{
			try
			{
				
				Boolean retorno = true;

				

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		#endregion

        #region "Metodos para as pesquisas"

        public System.Data.DataSet Pesquisa_E(List<String> ListaCodigos)
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();			
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

                System.Data.DataSet ds = VERBETE.Pesquisa_E(ListaCodigos);

				this.mensagem = VERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

        public System.Data.DataSet Pesquisa_OU(List<String> ListaCodigos)
        {
            try
            {
                cls_VERBETE VERBETE = new cls_VERBETE();

                VERBETE.VERBETE = this.VERBETE;
                VERBETE.NOME = this.NOME;
                VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
                VERBETE.DATACRIACAO = this.DATACRIACAO;
                VERBETE.DATAALTERACAO = this.DATAALTERACAO;
                VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

                System.Data.DataSet ds = VERBETE.Pesquisa_OU(ListaCodigos);

                this.mensagem = VERBETE.mensagem;

                return ds;
            }
            catch (Exception ex)
            {
                this.mensagem = ex.Message;
                return null;
            }
        }

        public System.Data.DataSet Pesquisa_EE(List<String> ListaCodigos)
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();			
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

                System.Data.DataSet ds = VERBETE.Pesquisa_EE(ListaCodigos);

				this.mensagem = VERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

        public System.Data.DataSet Pesquisa_TIT(List<String> ListaCodigos)
		{
			try
			{
				cls_VERBETE VERBETE = new cls_VERBETE();			
				
				VERBETE.VERBETE = this.VERBETE;
				VERBETE.NOME = this.NOME;
				VERBETE.NOMEORDENACAO = this.NOMEORDENACAO;
				VERBETE.DATACRIACAO = this.DATACRIACAO;
				VERBETE.DATAALTERACAO = this.DATAALTERACAO;
				VERBETE.DATAINCLUSAO = this.DATAINCLUSAO;

                System.Data.DataSet ds = VERBETE.Pesquisa_TIT(ListaCodigos);

				this.mensagem = VERBETE.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}


        #endregion
    }
}