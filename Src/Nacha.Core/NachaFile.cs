using System.Collections.Generic;

namespace Nacha.Core
{
	public class NachaFile
	{
		public enum RecordTypeCode
		{
			FileHeaderRecord = 1,
			BatchHeaderRecord = 5,
			EntryDetailRecord = 6,
			EntryDetailAddendaRecord = 7,
			BatchControlRecord = 8,
			FileControlRecord = 9
		}

		public const int BLOCKING_FACTOR = 10;
		public const int MAX_CHARACTERS_PER_LINE = 94;
		public const string PRIORITY_CODE = "01";
		public const string DATE_FORMAT = "yyMMdd";
		public const string TIME_FORMAT = "HHmm";
		public const string RECORD_SIZE = "094";
		public const string FORMAT_CODE = "1";
		public const string DEFAULT_FILE_ID_MODIFIER = "A";

		public const string TOSTRING_ERROR_MSG =
			"This record object must be validated before writing it to a string. Use the Validate() method.";

		private FileHeaderRecord _fileHeaderRecord;
		private readonly List<Batch> _batches;
		private FileControlRecord _fileControlRecord;

		public int BatchCount
		{
			get { return _batches.Count; }
		}

		public NachaFile(FileHeaderRecord a_FileHeader, List<Batch> a_Batches, FileControlRecord a_FileControlRecord)
		{
			_fileHeaderRecord = a_FileHeader;
			_batches = a_Batches;
			_fileControlRecord = a_FileControlRecord;
		}
	}
}
