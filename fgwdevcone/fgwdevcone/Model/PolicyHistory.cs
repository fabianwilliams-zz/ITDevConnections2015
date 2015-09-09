using System;

namespace fgwdevcone
{
	public class PolicyHistory
	{
		public string Id {get; set;}
		public string EvaluatedServer { get; set; }
		public DateTime EvaluationDateTime { get; set; }
		public string EvaluatedPolicy { get; set; }
		public string EvaluationResults { get; set; }
	}
}

