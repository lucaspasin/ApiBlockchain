using ApiBlockchain.Miner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiBlockchain.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlockController : ControllerBase
    {
        private readonly ILogger<BlockController> _logger;
        private readonly BlockMiner _blockMiner;
        private readonly TransactionPool _transactionPool;

        public BlockController(ILogger<BlockController> logger, BlockMiner blockMiner, TransactionPool transactionPool)
        {
            _logger = logger;
            _blockMiner = blockMiner;
            _transactionPool = transactionPool;
        }

        [HttpGet]
        [Route("/blocks")]
        public string Blocks() => JsonSerializer.Serialize(_blockMiner.Blockchain);

        [HttpGet]
        [Route("/blocks/{index}")]
        public string GetBlocksByIndex(int index)
        {
            Entity.Block block = null;
            if (index < _blockMiner.Blockchain.Count)
                block = _blockMiner.Blockchain[index];
            return JsonSerializer.Serialize(block);
        }

        [HttpGet]
        [Route("/latest")]
        public string GetLatestBlocks()
        {
            var block = _blockMiner.Blockchain.LastOrDefault();
            return JsonSerializer.Serialize(block);
        }

        [HttpPost]
        [Route("/add")]
        public void AddTransaction([FromBody] Entity.Transaction transaction)
        {
                _transactionPool.AddRaw(transaction);
        }
    }
}
