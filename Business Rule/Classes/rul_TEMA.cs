using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_TEMA
	{

		#region "Variaveis" 

			private  int _TEMA = -1;
			private  String _NOME = String.Empty;
			private  String _DESCRICAO = String.Empty;


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_TEMA()
		{
		}
		public rul_TEMA( int par_TEMA)
		{
			try
				{
					this.TEMA = par_TEMA;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int TEMA
			{
				get {return _TEMA;}
				set {_TEMA = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
			}

			public  String DESCRICAO
			{
				get {return _DESCRICAO;}
				set {_DESCRICAO = value;}
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
				cls_TEMA TEMA = new cls_TEMA();
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

				this.mensagem="";

				Boolean retorno = TEMA.Insert();

				this.mensagem = TEMA.mensagem;

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
				cls_TEMA TEMA = new cls_TEMA();
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

				this.mensagem= "";
				
				Boolean retorno = TEMA.Update();

				this.mensagem = TEMA.mensagem;

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
				if (  this.DESCRICAO == String.Empty)
				{
					this.mensagem = "O Campo DESCRICAO tem que ser preenchido com Texto";
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
				cls_TEMA TEMA = new cls_TEMA();

				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = TEMA.Delete();

						this.mensagem = TEMA.mensagem;

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
				cls_TEMA TEMA = new cls_TEMA();
				

				this.mensagem= "";
				
				Boolean retorno = TEMA.DeleteMasterDetail();

				this.mensagem = TEMA.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_TEMA GetAll()
		{
			try
			{
				cls_TEMA TEMA = new cls_TEMA();
				col_TEMA colecao = new col_TEMA();
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

				System.Data.DataSet ds = TEMA.GetAll();

                		if (TEMA.mensagem != String.Empty)
		                {
		                    this.mensagem = TEMA.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_TEMA item = new rul_TEMA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.TEMA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DESCRICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();


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
				cls_TEMA TEMA = new cls_TEMA();			
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

				System.Data.DataSet ds = TEMA.GetAll();

				this.mensagem = TEMA.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_TEMA FindAll()
		{

			cls_TEMA TEMA = new cls_TEMA();
			col_TEMA colecao = new col_TEMA();
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

			System.Data.DataSet ds = TEMA.FindAll();

               		if (TEMA.mensagem != String.Empty)
	                {
	                    this.mensagem = TEMA.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_TEMA item = new rul_TEMA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.TEMA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DESCRICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public col_TEMA FindAllGrid()
		{

			cls_TEMA TEMA = new cls_TEMA();
			col_TEMA colecao = new col_TEMA();
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

			System.Data.DataSet ds = TEMA.FindAllGrid();

               		if (TEMA.mensagem != String.Empty)
	                {
	                    this.mensagem = TEMA.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_TEMA item = new rul_TEMA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.TEMA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DESCRICAO = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Trim();


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_TEMA TEMA = new cls_TEMA();			
				
				TEMA.TEMA = this.TEMA;
				TEMA.NOME = this.NOME;
				TEMA.DESCRICAO = this.DESCRICAO;

				System.Data.DataSet ds = TEMA.FindAll();

				this.mensagem = TEMA.mensagem;

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
				cls_TEMA TEMA = new cls_TEMA();			
				

				System.Data.DataSet ds = TEMA.GetAllMasterDetail();

				this.mensagem = TEMA.mensagem;

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
				cls_TEMA TEMA = new cls_TEMA();


				
				TEMA.TEMA = this.TEMA;


				System.Data.DataSet ds = TEMA.Load();


                		if (TEMA.mensagem != String.Empty)
		                {
		                    this.mensagem = TEMA.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.TEMA = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.NOME = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.DESCRICAO = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[2]);


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

        #region "Metodos para trazer os verbetes de um tema"

        public System.Data.DataSet RetornaVerbetesTema()
		{
			try
			{
				cls_TEMA TEMA = new cls_TEMA();			
				
				TEMA.TEMA = this.TEMA;

                System.Data.DataSet ds = TEMA.RetornaVerbetesTema();

				this.mensagem = TEMA.mensagem;

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