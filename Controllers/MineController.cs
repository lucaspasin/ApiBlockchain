using ApiBlockchain.Miner;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiBlockchain.Controllers
{
    public class MineController : ControllerBase
    {
        private readonly ILogger<MineController> _logger;
        private readonly BlockMiner _blockMiner;
        private readonly TransactionPool _transactionPool;

        public MineController(ILogger<MineController> logger, BlockMiner blockMiner, TransactionPool transactionPool)
        {
            _logger = logger;
            _blockMiner = blockMiner;
            _transactionPool = transactionPool;
        }

        [HttpGet]
        [Route("/start")]
        public void Start() => _blockMiner.Start();

        [HttpGet]
        [Route("/stop")]
        public void Stop() => _blockMiner.Stop();
    }
}
