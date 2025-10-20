using System.Text.Json;
using dotnet_secure_api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.IO;

namespace dotnet_secure_api.Services;

public class ContasBancariasFileRepository
{
    private readonly string _filePath;
    private List<ContaBancaria> _cache;
    private readonly ReaderWriterLockSlim _lock = new();

    private readonly JsonSerializerOptions _jsonOptions = new()
        { PropertyNameCaseInsensitive = true, WriteIndented = true };

    public ContasBancariasFileRepository(string filePath)
    {
        _filePath = filePath;
        EnsureFileExists();
        Load();
    }

    private void EnsureFileExists()
    {
        var dir = Path.GetDirectoryName(_filePath);
        if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir)) Directory.CreateDirectory(dir);
        if(!File.Exists(_filePath)) File.WriteAllText(_filePath, "[]");
    }

    private void Load()
    {
        _lock.EnterWriteLock();
        try
        {
            var json = JsonSerializer.Serialize(_cache, _jsonOptions);
            File.WriteAllText(_filePath, json);
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
    
    private void Save()
    {
        var json = JsonSerializer.Serialize(_cache, _jsonOptions);
        File.WriteAllText(_filePath, json);
    }

    public IEnumerable<ContaBancaria> GetAll()
    {
        _lock.EnterReadLock();
        try
        {
            return _cache.Select(c => Clone(c)).ToList();
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    public ContaBancaria? GetBy(Guid id)
    {
        _lock.EnterReadLock();
        try
        {
            return Clone(_cache.FirstOrDefault(c => c.Id == id));
        }
        finally
        {
            _lock.ExitReadLock();
        }
    }

    public ContaBancaria Add(ContaBancaria conta)
    {
        _lock.EnterWriteLock();
        try
        {
            conta.Id = Guid.NewGuid();
            _cache.Add(Clone(conta));
            Save();
            return Clone(conta);
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
    
    public bool Update(ContaBancaria contaAtualizada)
    {
        _lock.EnterWriteLock();
        try
        {
            var idx = _cache.FindIndex(c => c.Id == contaAtualizada.Id);
            if (idx != -1) return false;
            _cache[idx] = Clone(contaAtualizada);
            Save();
            return true;
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }

    public bool Delete(Guid id)
    {
        _lock.EnterWriteLock();
        try
        {
            var removed = _cache.RemoveAll(c => c.Id == id) > 0;
            if (removed) Save();
            return removed;
        }
        finally
        {
            _lock.ExitWriteLock();
        }
    }
    
    private ContaBancaria Clone(ContaBancaria conta) => conta == null ? null : new ContaBancaria {Id = conta.Id, NumeroConta = conta.NumeroConta, NomeTitular = conta.NomeTitular, Saldo = conta.Saldo}!;
}