using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using VNIIA.ClientServerLibrary.Dtos;
using VNIIA.ClientServerLibrary.Attributes;
using VNIIA.Client.ViewModels;

namespace VNIIA.Client.Helpers
{
	public  static class DataTool
	{

		/// <summary>
		/// Генерирует колонки и заполняет данными DataTable
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dataTable"></param>
		/// <param name="collection"></param>
		/// <param name="ignoreCollectionPropperty">не генерировать колонки для свойств типа коллекция</param>
		public static void GenerateDataTableAndFillDataForDto<T>(this DataTable dataTable, IEnumerable<T> collection, bool ignoreCollectionPropperty = false) where T : EntityDto
		{
			DataColumn column;
			DataRow row;
			var mainType = typeof(T);
			dataTable.TableName = mainType.Name.Replace("Dto", "");
			if (mainType.BaseType != null && mainType.BaseType == typeof(EntityDto))
			{
				var propertiesInfo = from property in mainType.GetProperties()
									 where Attribute.IsDefined(property, typeof(OrderAttribute))
									 orderby ((OrderAttribute)property
											   .GetCustomAttributes(typeof(OrderAttribute), false)
											   .Single()).Order
									 select property;

				foreach (var property in propertiesInfo)
				{
					column = new DataColumn();
					if (property.DeclaringType != null && property.DeclaringType == typeof(EntityDto))
					{
						column.DataType = property.PropertyType;
						column.ColumnName = property.Name;
						column.AutoIncrement = false;
						column.DefaultValue = Activator.CreateInstance(property.PropertyType);
						column.ReadOnly = true;
						column.Unique = true;
						dataTable.Columns.Add(column);

						DataColumn[] PrimaryKeyColumns = new DataColumn[1];
						PrimaryKeyColumns[0] = dataTable.Columns[property.Name];
						dataTable.PrimaryKey = PrimaryKeyColumns;
						continue;
					}

					column.DataType = property.PropertyType;
					column.ColumnName = property.Name;
					column.AutoIncrement = false;
					column.ReadOnly = false;
					column.Unique = false;
					dataTable.Columns.Add(column);
				}

				foreach (T item in collection)
				{
					row = dataTable.NewRow();
					foreach (DataColumn col in dataTable.Columns)
					{
						row[col.ColumnName] = typeof(T).GetProperty(col.ColumnName).GetValue(item);
					}
					dataTable.Rows.Add(row);
				}

			}
		}

		/// <summary>
		/// Генерирует колонки и заполняет данными DataTable
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="dataTable"></param>
		/// <param name="collection"></param>
		/// <param name="ignoreCollectionPropperty">не генерировать колонки для свойств типа коллекция</param>
		public static void GenerateDataTableAndFillDataForViewModel<T>(this DataTable dataTable, IEnumerable<T> collection) where T : NotifyPropertyChangedViewModel
		{
			DataColumn column;
			DataRow row;
			var mainType = typeof(T);
			dataTable.TableName = mainType.Name.Replace("ViewModel", "");
			if (mainType.BaseType != null)
			{
				var propertiesInfo = from property in mainType.GetProperties()
									 where Attribute.IsDefined(property, typeof(OrderAttribute))
									 orderby ((OrderAttribute)property
											   .GetCustomAttributes(typeof(OrderAttribute), false)
											   .Single()).Order
									 select property;
				int MinOrderValue = (propertiesInfo.First().GetCustomAttributes(typeof(OrderAttribute), false)
											   .Single() as OrderAttribute)?.Order ?? int.MaxValue;

				foreach (var property in propertiesInfo)
				{
					column = new DataColumn();
					if (property.DeclaringType != null && ((OrderAttribute)property.GetCustomAttributes(typeof(OrderAttribute), false).Single()).Order == MinOrderValue)
					{
						column.DataType = property.PropertyType;
						column.ColumnName = property.Name;
						column.Caption = "Индентификатор";
						column.AutoIncrement = false;
						column.DefaultValue = Activator.CreateInstance(property.PropertyType);
						column.ReadOnly = true;
						column.Unique = true;
						dataTable.Columns.Add(column);

						DataColumn[] PrimaryKeyColumns = new DataColumn[1];
						PrimaryKeyColumns[0] = dataTable.Columns[property.Name];
						dataTable.PrimaryKey = PrimaryKeyColumns;
						continue;
					}

					column.DataType = property.PropertyType;
					column.ColumnName = property.Name;
					column.AutoIncrement = false;
					column.ReadOnly = false;
					column.Unique = false;
					dataTable.Columns.Add(column);
				}

				foreach (T item in collection)
				{
					row = dataTable.NewRow();
					foreach (DataColumn col in dataTable.Columns)
					{
						row[col.ColumnName] = typeof(T).GetProperty(col.ColumnName).GetValue(item);
					}
					dataTable.Rows.Add(row);
				}

			}
		}


		/// <summary>
		/// Возвращает дефолтное значение, аналог default(type)
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static object GetDefault(this Type type)
		{
			return (type.IsValueType) ? Activator.CreateInstance(type) : null;
		}
	}
}
