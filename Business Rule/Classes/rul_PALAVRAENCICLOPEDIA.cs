using System;
using System.Drawing;
using EnciclopediaJuridica.BusinessClass;
using EnciclopediaJuridica.BusinessCollection;


namespace EnciclopediaJuridica.BusinessRule
{
	public class rul_PALAVRAENCICLOPEDIA
	{

		#region "Variaveis" 

			private  int _PALAVRAENCICLOPEDIA = -1;
			private  String _NOME = String.Empty;
			private  DateTime _DATAINCLUSAO = new DateTime();


			private String _mensagem = "";
			private Boolean _NovoRegistro = true;

		#endregion

		#region "Construtures"
 
		public rul_PALAVRAENCICLOPEDIA()
		{
		}
		public rul_PALAVRAENCICLOPEDIA( int par_PALAVRAENCICLOPEDIA)
		{
			try
				{
					this.PALAVRAENCICLOPEDIA = par_PALAVRAENCICLOPEDIA;
 
					this.NovoRegistro = !this.Load();
				}
			catch(Exception ex)
				{
					this.mensagem = ex.Message;
				}

		}

		#endregion

		#region "Propriedades"
 
			public  int PALAVRAENCICLOPEDIA
			{
				get {return _PALAVRAENCICLOPEDIA;}
				set {_PALAVRAENCICLOPEDIA = value;}
			}

			public  String NOME
			{
				get {return _NOME;}
				set {_NOME = value;}
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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

				this.mensagem="";

				Boolean retorno = PALAVRAENCICLOPEDIA.Insert();

				this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

				this.mensagem= "";
				
				Boolean retorno = PALAVRAENCICLOPEDIA.Update();

				this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();

				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;


				if (VerifyForeignKeys())
					{

						this.mensagem= "";
				
						Boolean retorno = PALAVRAENCICLOPEDIA.Delete();

						this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();
				

				this.mensagem= "";
				
				Boolean retorno = PALAVRAENCICLOPEDIA.DeleteMasterDetail();

				this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

				return retorno;

			}
			catch(Exception ex)
			{
			this.mensagem = ex.Message;
			return false;
			}
		}

		public col_PALAVRAENCICLOPEDIA GetAll()
		{
			try
			{
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();
				col_PALAVRAENCICLOPEDIA colecao = new col_PALAVRAENCICLOPEDIA();
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

				System.Data.DataSet ds = PALAVRAENCICLOPEDIA.GetAll();

                		if (PALAVRAENCICLOPEDIA.mensagem != String.Empty)
		                {
		                    this.mensagem = PALAVRAENCICLOPEDIA.mensagem;
		                    return null;
		                }

				for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
				{
					rul_PALAVRAENCICLOPEDIA item = new rul_PALAVRAENCICLOPEDIA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.PALAVRAENCICLOPEDIA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2]);


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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();			
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

				System.Data.DataSet ds = PALAVRAENCICLOPEDIA.GetAll();

				this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

				return ds;
			}
			catch (Exception ex)
			{
				this.mensagem = ex.Message;
				return null;
			}
		}

		public col_PALAVRAENCICLOPEDIA FindAll()
		{

			cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();
			col_PALAVRAENCICLOPEDIA colecao = new col_PALAVRAENCICLOPEDIA();
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

			System.Data.DataSet ds = PALAVRAENCICLOPEDIA.FindAll();

               		if (PALAVRAENCICLOPEDIA.mensagem != String.Empty)
	                {
	                    this.mensagem = PALAVRAENCICLOPEDIA.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_PALAVRAENCICLOPEDIA item = new rul_PALAVRAENCICLOPEDIA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.PALAVRAENCICLOPEDIA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}


		public col_PALAVRAENCICLOPEDIA FindAllGrid()
		{

			cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();
			col_PALAVRAENCICLOPEDIA colecao = new col_PALAVRAENCICLOPEDIA();
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

			System.Data.DataSet ds = PALAVRAENCICLOPEDIA.FindAllGrid();

               		if (PALAVRAENCICLOPEDIA.mensagem != String.Empty)
	                {
	                    this.mensagem = PALAVRAENCICLOPEDIA.mensagem;
	                    return null;
	                }


			for ( int i =0 ; i <  ds.Tables[0].Rows.Count ; i++)
			{
				rul_PALAVRAENCICLOPEDIA item = new rul_PALAVRAENCICLOPEDIA();
					if( ds.Tables[0].Rows[i].ItemArray[0].ToString() != String.Empty)
						item.PALAVRAENCICLOPEDIA = Convert.ToInt32(ds.Tables[0].Rows[i].ItemArray[0]);

					if( ds.Tables[0].Rows[i].ItemArray[1].ToString() != String.Empty)
						item.NOME = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Trim();

					if( ds.Tables[0].Rows[i].ItemArray[2].ToString() != String.Empty)
						item.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[i].ItemArray[2]);


				item.NovoRegistro = false;
				colecao.Add(item);
			}
			
			return colecao;

		}

		public System.Data.DataSet FindAllInDataSet()
		{
			try
			{
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();			
				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;
				PALAVRAENCICLOPEDIA.NOME = this.NOME;
				PALAVRAENCICLOPEDIA.DATAINCLUSAO = this.DATAINCLUSAO;

				System.Data.DataSet ds = PALAVRAENCICLOPEDIA.FindAll();

				this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();			
				

				System.Data.DataSet ds = PALAVRAENCICLOPEDIA.GetAllMasterDetail();

				this.mensagem = PALAVRAENCICLOPEDIA.mensagem;

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
				cls_PALAVRAENCICLOPEDIA PALAVRAENCICLOPEDIA = new cls_PALAVRAENCICLOPEDIA();


				
				PALAVRAENCICLOPEDIA.PALAVRAENCICLOPEDIA = this.PALAVRAENCICLOPEDIA;


				System.Data.DataSet ds = PALAVRAENCICLOPEDIA.Load();


                		if (PALAVRAENCICLOPEDIA.mensagem != String.Empty)
		                {
		                    this.mensagem = PALAVRAENCICLOPEDIA.mensagem;
		                    return false;
		                }


				if( ds.Tables[0].Rows.Count ==1)
				{
										if( ds.Tables[0].Rows[0].ItemArray[0].ToString() != String.Empty)
						this.PALAVRAENCICLOPEDIA = Convert.ToInt32(ds.Tables[0].Rows[0].ItemArray[0]);

					if( ds.Tables[0].Rows[0].ItemArray[1].ToString() != String.Empty)
						this.NOME = Convert.ToString(ds.Tables[0].Rows[0].ItemArray[1]);

					if( ds.Tables[0].Rows[0].ItemArray[2].ToString() != String.Empty)
						this.DATAINCLUSAO = Convert.ToDateTime(ds.Tables[0].Rows[0].ItemArray[2]);


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
	}
}