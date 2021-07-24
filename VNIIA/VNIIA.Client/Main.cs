using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;

using VNIIA.Client.Common;
using VNIIA.Client.Helpers;
using VNIIA.Client.Services;
using VNIIA.Client.ViewModels;
using VNIIA.ClientServerLibrary.Dtos;

namespace VNIIA.Client
{
	public partial class Main : Form
	{
		private BindingSource _documentBindingSource;
		private BindingSource _documentpositionBindingSource;
		private IBaseService<DocumentDto, HttpClient> _documentService;
		private IBaseService<DocumentPositionDto, HttpClient> _documentPositionService;

		public Main(BindingSource documentBindingSource, BindingSource documentpositionBindingSource,
			IBaseService<DocumentDto,HttpClient>  documentService, IBaseService<DocumentPositionDto, HttpClient> documentPositionService)
		{
			InitializeComponent();
			_documentBindingSource = documentBindingSource;
			_documentpositionBindingSource = documentpositionBindingSource;

			_documentService = documentService;
			_documentPositionService = documentPositionService;
			Load += Main_Load;
			FormClosing += Main_FormClosing;
		}

		private void Main_FormClosing(object sender, FormClosingEventArgs e)
		{
			Unsubscribe();
		}

		private async void Main_Load(object sender, EventArgs e)
		{
			dgw_Documents.DataSource = _documentBindingSource;
			dgw_DocumentPositions.DataSource = _documentpositionBindingSource;

			try
			{
				await _documentService.GetAllAsync().ContinueWith(data =>
				{
					dgw_Documents.HelpInvoke(() =>
					{
						try
						{
							_documentBindingSource.DataSource = data.Result.ToViewModel();
						}
						catch (System.AggregateException ae)
						{
							MessageBox.Show(ae.InnerExceptions.Select(c => c.Message).Aggregate((a, b) => a + Environment.NewLine + b), "Ошибка изменения записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return;
						}
						catch (OperationCanceledException oce)
						{
							MessageBox.Show(oce.Message, DialogConsts.ERROR_LOAD_DATA, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, DialogConsts.ERROR_LOAD_DATA, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

					});

					dgw_DocumentPositions.HelpInvoke(() =>
					{
						try
						{
							_documentpositionBindingSource.DataSource = _documentBindingSource;
							_documentpositionBindingSource.DataMember = "DocumentPositions";
						}
						catch (System.AggregateException ae)
						{
							MessageBox.Show(ae.InnerExceptions.Select(c => c.Message).Aggregate((a, b) => a + Environment.NewLine + b), "Ошибка изменения записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch (OperationCanceledException oce)
						{
							MessageBox.Show(oce.Message, DialogConsts.ERROR_LOAD_DATA, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						catch (Exception ex)
						{
							MessageBox.Show(ex.Message, DialogConsts.ERROR_LOAD_DATA, MessageBoxButtons.OK, MessageBoxIcon.Error);
						}

					});

					Subscribes();
					SetAppearance();
				});
			}
			catch (AggregateException ae)
			{
				MessageBox.Show(ae.InnerExceptions.Select(c => c.Message).Aggregate((a, b) => a + Environment.NewLine + b), "Ошибка изменения записи", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (OperationCanceledException oce)
			{
				MessageBox.Show(oce.Message, DialogConsts.ERROR_LOAD_DATA, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, DialogConsts.ERROR_LOAD_DATA, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}


		/// <summary>
		/// Устанавливает внешний вид колонкам
		/// </summary>
		private void SetAppearance() 
		{
			dgw_Documents.HelpInvoke(() =>
			{
				_documentBindingSource.AllowNew = true;
				dgw_Documents.AutoGenerateColumns = true;

				if (dgw_Documents.Columns.Count > 0)
				{
					//Устанавливаем формат даты для колонки с датами
					dgw_Documents.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm:ss";

					foreach (DataGridViewColumn column in dgw_Documents.Columns)
					{
						//Устанавливаем размер по содержимому для всех колонок, кроме текстовых
						if (column.ValueType != typeof(string))
							column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						else
							column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

					}
				}
			});

			dgw_DocumentPositions.HelpInvoke(
				()=>
				{
					dgw_DocumentPositions.AutoGenerateColumns = true;
					foreach (DataGridViewColumn column in dgw_DocumentPositions.Columns)
					{
						//Устанавливаем размер по содержимому для всех колонок, кроме текстовых
						if (column.ValueType != typeof(string))
							column.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
						else
							column.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

					}
				});
		}

		private void _documentBindingSource_CurrentChanged(object sender, EventArgs e)
		{
			if(!_documentpositionBindingSource.AllowNew)
			{
				_documentpositionBindingSource.AllowNew = true;
			}
		}

		/// <summary>
		/// Выполняет необходимые подписки
		/// </summary>
		private void Subscribes()
		{
			_documentBindingSource.AddingNew += _documentBindingSource_AddingNew;
			_documentpositionBindingSource.AddingNew += _documentpositionBindingSource_AddingNew;

			_documentBindingSource.ListChanged += _documentBindingSource_ListChanged;
			_documentpositionBindingSource.ListChanged += _documentpositionBindingSource_ListChanged;
			
			dgw_Documents.UserDeletingRow += Dgw_Documents_UserDeletingRow;
			dgw_DocumentPositions.UserDeletingRow += Dgw_DocumentPositions_UserDeletingRow;

			dgw_Documents.DataError += Dgw_Documents_DataError;
			dgw_DocumentPositions.DataError += Dgw_DocumentPositions_DataError;

			_documentBindingSource.CurrentChanged += _documentBindingSource_CurrentChanged;
		}

		/// <summary>
		/// Выполняет необходимые отписки
		/// </summary>
		private void Unsubscribe()
		{
			FormClosing -= Main_FormClosing;
			Load -= Main_Load;

			_documentBindingSource.AddingNew -= _documentBindingSource_AddingNew;
			_documentpositionBindingSource.AddingNew -= _documentpositionBindingSource_AddingNew;

			_documentBindingSource.ListChanged -= _documentBindingSource_ListChanged;
			_documentpositionBindingSource.ListChanged -= _documentpositionBindingSource_ListChanged;

			dgw_Documents.UserDeletingRow -= Dgw_Documents_UserDeletingRow;
			dgw_DocumentPositions.UserDeletingRow -= Dgw_DocumentPositions_UserDeletingRow;

			dgw_Documents.DataError -= Dgw_Documents_DataError;
			dgw_DocumentPositions.DataError -= Dgw_DocumentPositions_DataError;

			_documentBindingSource.CurrentChanged -= _documentBindingSource_CurrentChanged;
		}

		private void _documentpositionBindingSource_AddingNew(object sender, AddingNewEventArgs e)
		{
			if (_documentBindingSource.Current != null)
			{
				e.NewObject = new DocumentPositionViewModel(0, (_documentBindingSource.Current as DocumentViewModel).Number);
			}
		}

		private void _documentBindingSource_AddingNew(object sender, AddingNewEventArgs e)
		{
			e.NewObject = new DocumentViewModel(0) { Date = DateTime.Now};
		}

		private async void _documentpositionBindingSource_ListChanged(object sender, ListChangedEventArgs e)
		{
			try
			{
				switch (e.ListChangedType)
				{
					case ListChangedType.ItemAdded:
						{
							try
							{
								if (_documentpositionBindingSource.List is IList<DocumentPositionViewModel> collection)
								{
									if (collection != null)
									{
										var docDto = collection.ElementAtOrDefault<DocumentPositionViewModel>(e.NewIndex)?.ToDto() ?? null;

										if (docDto != null) await _documentPositionService.CreateAsync(docDto)
																.ContinueWith(doc =>
																{
																	docDto.Number = doc.Result.Number;
																	docDto.Sum = doc.Result.Sum;
																	docDto.DocumentId = doc.Result.DocumentId;
																	dgw_Documents.HelpInvoke(() =>
																	{
																		_documentpositionBindingSource.ListChanged -= _documentpositionBindingSource_ListChanged;
																		_documentpositionBindingSource.List.RemoveAt(e.NewIndex);
																		_documentpositionBindingSource.CurrencyManager.Position = ((e.NewIndex - 1) < 0) ? 0 : e.NewIndex - 1;
																		_documentpositionBindingSource.CurrencyManager.Position = ((e.NewIndex - 1) < 0) ? 0 : e.NewIndex - 1;
																		var tt = _documentpositionBindingSource.List.Add(docDto.ToViewModel());
																		_documentpositionBindingSource.ListChanged += _documentpositionBindingSource_ListChanged;
																	});
																});
									}
								}
							}
							catch (OperationCanceledException oce)
							{
								MessageBox.Show(oce.Message, DialogConsts.ERROR_CREATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, DialogConsts.ERROR_CREATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						break;
					case ListChangedType.ItemChanged:
						{
							try
							{
								if (_documentpositionBindingSource.List is IList<DocumentPositionViewModel> collection)
								{
									if (collection != null)
									{
										_documentpositionBindingSource.ListChanged -= _documentpositionBindingSource_ListChanged;
										var docDto = collection.ElementAtOrDefault<DocumentPositionViewModel>(e.NewIndex)?.ToDto();
										if (docDto != null) await _documentPositionService.UpdateAsync(docDto);
										_documentpositionBindingSource.ListChanged += _documentpositionBindingSource_ListChanged;
									}
								}
							}
							catch (OperationCanceledException oce)
							{
								MessageBox.Show(oce.Message, DialogConsts.ERROR_UPDATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, DialogConsts.ERROR_UPDATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void _documentBindingSource_ListChanged(object sender, ListChangedEventArgs e)
		{
			try
			{
				switch (e.ListChangedType)
				{
					case ListChangedType.ItemAdded:
						{
							try
							{
								if (_documentBindingSource.DataSource is ICollection<DocumentViewModel> collection)
								{
									if (collection != null)
									{
										var docDto = collection.ElementAtOrDefault<DocumentViewModel>(e.NewIndex)?.ToDto() ?? null;

										if (docDto != null) await _documentService.CreateAsync(docDto)
																.ContinueWith(doc =>
																{
																	docDto.Number = doc.Result.Number;
																	docDto.Date = doc.Result.Date;
																	docDto.Amount = doc.Result.Amount;
																	docDto.Note = doc.Result.Note;
																	dgw_Documents.HelpInvoke(() =>
																	{
																		_documentBindingSource.ListChanged -= _documentBindingSource_ListChanged;
																		_documentBindingSource.RemoveAt(e.NewIndex);
																		_documentBindingSource.CurrencyManager.Position = ((e.NewIndex - 1) < 0) ? 0 : e.NewIndex - 1;
																		_documentBindingSource.CurrencyManager.Position = ((e.NewIndex - 1) < 0) ? 0 : e.NewIndex - 1;
																		var tt = _documentBindingSource.Add(docDto.ToViewModel());
																		_documentBindingSource.ListChanged += _documentBindingSource_ListChanged;
																	});
																});
									}
								}
							}
							catch (OperationCanceledException oce)
							{
								MessageBox.Show(oce.Message, DialogConsts.ERROR_CREATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, DialogConsts.ERROR_CREATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						break;
					case ListChangedType.ItemChanged:
						{
							try
							{
								if (_documentBindingSource.DataSource is ICollection<DocumentViewModel> collection)
								{
									if (collection != null)
									{
										_documentBindingSource.ListChanged -= _documentBindingSource_ListChanged;
										var docDto = collection.ElementAtOrDefault<DocumentViewModel>(e.NewIndex)?.ToDto();
										if (docDto != null) await _documentService.UpdateAsync(docDto);
										_documentBindingSource.ListChanged += _documentBindingSource_ListChanged;
									}
								}
							}
							catch (OperationCanceledException oce)
							{
								MessageBox.Show(oce.Message, DialogConsts.ERROR_UPDATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							catch (Exception ex)
							{
								MessageBox.Show(ex.Message, DialogConsts.ERROR_UPDATE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
						break;
					default:
						break;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void Dgw_DocumentPositions_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			try
			{
				int itemId = Convert.ToInt32(e.Row.Cells[0]?.Value ?? 0);
				if (itemId != 0) await _documentPositionService.DeleteAsync(itemId);
			}
			catch (OperationCanceledException oce)
			{
				MessageBox.Show(oce.Message, DialogConsts.ERROR_DELETE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, DialogConsts.ERROR_DELETE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private async void Dgw_Documents_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
		{
			try
			{
				int itemId = Convert.ToInt32(e.Row.Cells[0]?.Value ?? 0);
				if (itemId != 0) await _documentService.DeleteAsync(itemId);
			}
			catch (OperationCanceledException oce)
			{
				MessageBox.Show(oce.Message, DialogConsts.ERROR_DELETE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, DialogConsts.ERROR_DELETE_RECORD, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void Dgw_DocumentPositions_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void Dgw_Documents_DataError(object sender, DataGridViewDataErrorEventArgs e)
		{
			MessageBox.Show(e.Exception.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}


	}
}
