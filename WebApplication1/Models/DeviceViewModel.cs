using TeamD_Database.Entity;

namespace WebApplication1.Models;

    public class DeviceViewModel
    {

        internal const char DLM = '$';
        public List<Device>? DeviceList { get; set; } = new List<Device>();

    public string? SearchString { get; set; }

        public string? SortField { get; set; }

        public string GetSortFieldParamValue(string sortFieldName)
        {
            var result = sortFieldName;
            string direction = "ASC";
            if (!string.IsNullOrEmpty(this.SortField) &&
                (this.SortField.StartsWith(sortFieldName, StringComparison.CurrentCultureIgnoreCase)))
            {
                string[] tokens = this.SortField.Split(DLM);
                if (tokens.Length > 1)
                {
                    var sortDirection = tokens[tokens.Length - 1];
                    if (sortDirection.Equals("ASC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        direction = "DESC";
                    }
                    else if (sortDirection.Equals("DESC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        direction = "ASC";
                    }
                }
            }
            result += DLM + direction;
            return result;
        }

        public string GetSortFieldDisplayName(string sortFieldName)
        {
            var result = sortFieldName;
            if (!string.IsNullOrEmpty(this.SortField) &&
                 (this.SortField.StartsWith(sortFieldName, StringComparison.CurrentCultureIgnoreCase)))
            {
                string direction = "▲";
                string[] tokens = this.SortField.Split(DLM);
                if (tokens.Length > 1)
                {
                    var sortDirection = tokens[tokens.Length - 1];
                    if (sortDirection.Equals("ASC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        direction = "▲";
                    }
                    else if (sortDirection.Equals("DESC", StringComparison.CurrentCultureIgnoreCase))
                    {
                        direction = "▼";
                    }
                }
                result += direction;
            }
            return result;
        }
    }




