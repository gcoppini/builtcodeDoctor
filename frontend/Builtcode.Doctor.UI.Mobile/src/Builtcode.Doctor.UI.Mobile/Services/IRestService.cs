using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Builtcode.Doctor.UI.Mobile.Models;

namespace Builtcode.Doctor.UI.Mobile.Services
{
    public interface IRestService
    {
        Task<List<T>> GetAsync<T>(string requestUrl) where T : class;
        Task SaveAsync<T>(T item, bool isNewItem = false) where T : class;
    }
}