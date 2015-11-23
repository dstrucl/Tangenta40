// ExcelObject.h

#pragma once

using namespace System;

namespace ExcelObject{


using namespace CompoundFiles;

#ifdef _WIN32
using namespace WinCompFiles;
#endif

struct CODE
{
	enum {	FORMULA=0x0006, 		//Token array and the result of a formula cell.
			YEOF=0x000A,			//End of a record block with leading BOF record.
			CALCCOUNT=0x000C,		//Maximum number of times the forumlas should be iteratively calculated
			CALCMODE=0x000D,		//Calculate formulas manually, automatically, or automatically except for multiple table operations
			PRECISION=0x000E,		//Whether formulas use the real cell values for calculation or the values displayed on the screen.
			REFMODE=0x000F, 		//Method used to show cell addresses in formulas.
			DELTA=0x0010,			//Maximum change of the result to exit an iteration.
			ITERATION=0x0011,		//Whether iterations are allowed while calculating recursive formulas.
			PROTECT=0x0012, 		//Whether worksheet or a workbook is protected against modification.
			PASSWORD=0x0013,		//16-bit hash value, calculated from the worksheet or workbook protection password.
			HEADER=0x0014,			//Page header string for the current worksheet.
			FOOTER=0x0015,			//Page footer string for the current worksheet.
			EXTERNSHEET=0x0017, 	//List with indexes to SUPBOOK records
			NAME=0x0018,			//Name and token array of an internal defined name.
			WINDOWPROTECT=0x0019,	//Whether the window configuration of the document is protected.
			SELECTION=0x001D,		//Addresses of all selected cell ranges and position of the active cell for a pane in the current sheet.
			DATEMODE=0x0022,		//Base date for displaying date values.
			EXTERNNAME=0x0023,		//Name of an external defined name, name of an add-in function, a DDE item or an OLE object storage identifier.
			LEFTMARGIN=0x0026,		//Left page margin of the current worksheet.
			RIGHTMARGIN=0x0027, 	//Right page margin of the current worksheet.
			TOPMARGIN=0x0028,		//Top page margin of the current worksheet.
			BOTTOMMARGIN=0x0029,	//Bottom page margin of current worksheet
			PRINTHEADERS=0x002A,	//Whether row and column headers (the areas with row numbers and column letters) will be printed.
			PRINTGRIDLINES=0x002B,	//Whether sheet grid lines will be printed.
			FILEPASS=0x002F,		//Information about the read/write password of the file.
			FONT=0x0031,			//Information about a used font, including character formatting.
			TABLE=0x0036,			//Information about a multiple operation table in the sheet.
			CONTINUE=0x003C,		//Continue from previous record
			WINDOW1=0x003D, 		//General settings for the workbook global settings.
			BACKUP=0x0040,			//Make backup of file while saving?
			PANE=0x0041,			//Position of window panes.
			CODEPAGE=0x0042,		//Text encoding used to encode byte strings
			DCONREF=0x0051,
			DEFCOLWIDTH=0x0055, 	//Default column width for columns that do not have a specific width set
			XCT=0x0059, 			//Number of immediately following CRN records.
			CRN=0x005A, 			//Contents of an external cell or cell range.
			FILESHARING=0x005B, 	//Information about write protection, for instance the write protection password.
			WRITEACCESS=0x005C, 	//Name of the user that has saved the file.
			UNCALCED=0x005E,		//Formulas have not been recalculated before the document was saved.
			SAVERECALC=0x005F,		//"Recalculate before save" option
			OBJECTPROTECT=0x0063,	//Whether objects of the current sheet are protected.
			COLINFO=0x007D, 		//Width for a given range of columns
			GUTS=0x0080,			//Layout of outline symbols.
			WSBOOL=0x0081,			//16-bit value with boolean options for the current sheet.
			GRIDSET=0x0082, 		//Whether option to print sheet grid lines has ever been changed.
			HCENTER=0x0083, 		//Sheet is centred horizontally when printed.
			VCENTER=0x0084, 		//Whether sheet is centred vertically when printed.
			BOUNDSHEET=0x0085,		//Sheet inside of the workbook
			WRITEPROT=0x0086,		//Whether file is write protected.
			COUNTRY=0x008C, 		//User interface language of the Excel version that has saved the file, system regional settings at the time the file was saved.
			HIDEOBJ=0x008D, 		//Whether and how to show objects in the workbook.
			SORT=0x0090,			//Last settings from the "Sort" dialogue for each sheet.
			PALETTE=0x0092, 		//Definition of all user-defined colours available for cell and object formatting.
			SETUP=0x00A1,			//Page format settings of the current sheet.
			SHRFMLA=0x00BC, 		//Token array of a shared formula.
			MULRK=0x00BD,			//Cell range containing RK value cells. All cells are located in the same row.
			MULBLANK=0x00BE,		//Cell range of empty cells. All cells are located in the same row.
			DBCELL=0x00D7,			//Relative offsets to calculate stream position of the first cell record for each row.
			BOOKBOOL=0x00DA,		//Save values linked from external workbooks records and XCT records?
			SCENPROTECT=0x00DD, 	//Whether scenarios of the current sheet are protected.
			XF=0x00E0,				//Formatting information for cells, rows, columns or styles.
			MERGECELLS=0x00E5, 		//All merged cell ranges of the current sheet.
			SST=0x00FC, 			//List of all strings used anywhere in the workbook.
			LABELSST=0x00FD,		//Cell that contains a string.
			EXTSST=0x00FF,			//Create a hash table with stream offsets to the SST record to optimise string search operations.
			LABELRANGES=0x015F, 	//Addresses of all row and column label ranges in the current sheet.
			USESELFS=0x0160,		//Whether formulas in the workbook can use "natural language formulas".
			DSF=0x0161, 			//Whether file contains an addition BIFF5/BIFF7 workbook stream.
			SUPBOOK=0x01AE, 		//URL of an external document and a list of sheet names inside this document.
			CONDFMT=0x01B0, 		//List of cell range addresses for all cells with equal conditional formatting.
			CF=0x01B1,				//Condition and the formatting attributes applied to the cells specified in the CONDFMT record, if the condition is met
			DVAL=0x01B2,			//List header of the data validity table in the current sheet.
			HLINK=0x01B8,			//One cell address or a cell range where all cells contain the same hyperlink.
			DV=0x01BE,				//Data validity settings and a list of cell ranges which contain these settings.
			DIMENSIONS=0x0200,		//Range address of the used area in the current sheet.
			BLANK=0x0201,			//Empty cell, contains cell address and formatting information
			NUMBER=0x0203,			//Cell that contains a floating-point value.
			BOOLERR=0x0205, 		//Error value cell
			STRING=0x0207,			//Result of a string formula.
			ROW=0x0208, 			//Properties of a single row in the sheet.
			INDEX=0x020B,			//Range of used rows and stream positions of several records of the current sheet.
			ARRAY=0x0221,			//Token array of an array formula
			WINDOW2=0x023E, 		//Additional settings for the window of a specific worksheet.
			RK=0x027E,				//Cell that contains an RK value (encoded integer or floating point value).
			STYLE=0x0293,			//Name of a user-defined cell style or specific options for a built-in cell style.
			FORMAT=0x041E,			//Number format.
			SHRFMLA1=0x04BC,		//Token array of a shared formula (added).
			QUICKTIP=0x0800,		//Cell range and text for a tool tip.
			BOF=0x0809, 			//Beginning of file
			SHEETLAYOUT=0x0862, 	//Colour of the tab below the sheet containing the sheet name.
			SHEETPROTECTION=0x0867, //Additional options for sheet protection.
			RANGEPROTECTION=0x0868,	//Information about special protected ranges in a protected sheet.
			SXFORMULA=0x0103,		//PivotTable Formula Record
		};
};

class Record
{
public:
	Record();
	virtual ~Record();
	virtual ULONG Read(const char* data);
	virtual ULONG Write(char* data);
	virtual ULONG DataSize();
	virtual ULONG RecordSize();
	USHORT code_;
	vector<char> data_;
	ULONG	dataSize_;
	ULONG	recordSize_;
	vector<ULONG> continueIndices_;
};

struct BOF : public Record
{
	BOF();
	virtual ULONG Read(const char* data);
	virtual ULONG Write(char* data);
	USHORT version_;
	USHORT type_;
	USHORT buildIdentifier_;
	USHORT buildYear_;
	ULONG fileHistoryFlags_;
	ULONG lowestExcelVersion_;
};

struct YEOF : public Record
{
	YEOF();
};

 // String with 1 byte length field
struct SmallString
{
	SmallString();
	~SmallString();
	SmallString(const SmallString& s);

	SmallString& operator=(const SmallString& s);
	const SmallString& operator=(const char* str);
	const SmallString& operator=(const wchar_t* str);

	void Reset();
	ULONG Read(const char* data);
	ULONG Write(char* data);
	ULONG DataSize();
	ULONG RecordSize();
	ULONG StringSize();

	wchar_t* wname_;
	char* name_;
	char unicode_;
};

 // String with 2 byte length field
struct LargeString
{
	LargeString();
	~LargeString();
	LargeString(const LargeString& s);

	LargeString& operator=(const LargeString& s);
	const LargeString& operator=(const char* str);
	const LargeString& operator=(const wchar_t* str);

	void Reset();
	ULONG Read(const char* data);
	ULONG ContinueRead(const char* data, int size);
	ULONG Write(char* data);
	ULONG DataSize();
	ULONG RecordSize();
	ULONG StringSize();

	vector<wchar_t> wname_;
	vector<char> name_;
	char unicode_;
	USHORT richtext_;
	ULONG phonetic_;
};


	//MF string conversion functions

inline std::string narrow_string(const vector<wchar_t>& wstr)
{
	return ::narrow_string(wstring(&*wstr.begin(), wstr.size()));
}

inline std::wstring widen_string(const vector<char>& wstr)
{
	return ::widen_string(string(&*wstr.begin(), wstr.size()));
}

inline string stringFromSmallString(const SmallString& ss)
{
	if (ss.unicode_)
		return ::narrow_string(ss.wname_);
	else
		return ss.name_;
}

inline string stringFromLargeString(const LargeString& ls)
{
	if (ls.unicode_)
		return narrow_string(ls.wname_);
	else
		return string(&*ls.name_.begin(), ls.name_.size());
}


inline wstring wstringFromSmallString(const SmallString& ss)
{
	if (ss.unicode_)
		return ss.wname_;
	else
		return ::widen_string(ss.name_);
}

inline wstring wstringFromLargeString(const LargeString& ls)
{
	if (ls.unicode_)
		return wstring(&*ls.wname_.begin(), ls.wname_.size());
	else
		return widen_string(ls.name_);
}


public ref class Workbook
{
public:
	Workbook();

public:
	struct FileProtection;
	struct CodePage;
	struct DSF;
	struct TabID;
	struct FnGroupCount;
	struct WorkbookProtection;
	struct Window1 : public Record
	{
		Window1();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		USHORT horizontalPos_;
		USHORT verticalPos_;
		USHORT width_;
		USHORT height_;
		USHORT options_;
		USHORT activeWorksheetIndex_;
		USHORT firstVisibleTabIndex_;
		USHORT selectedWorksheetNo_;
		USHORT worksheetTabBarWidth_;
	};
	struct Backup;
	struct HideObj;
	struct DateMode;
	struct Precision;
	struct RefreshAll;
	struct BookBool;
	struct Font : public Record
	{
		Font();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();
		USHORT height_;
		USHORT options_;
		USHORT colourIndex_;
		USHORT weight_;
		USHORT escapementType_;
		BYTE underlineType_;
		BYTE family_;
		BYTE characterSet_;
		BYTE unused_;
		SmallString name_;
	};
	struct Format : public Record
	{
		//MF
		Format();

		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();

		USHORT index_;
		LargeString fmtstring_;
	};
	struct XF : public Record
	{
		XF();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		USHORT fontRecordIndex_;
		USHORT formatRecordIndex_;
		USHORT protectionType_;
		BYTE alignment_;	// 0x08: 1 = Text is wrapped at right border
		BYTE rotation_;
		BYTE textProperties_;
		BYTE usedAttributes_;
		ULONG borderLines_;
		ULONG colour1_;
		USHORT colour2_;
	};
	struct Style : public Record
	{
		Style();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();
		USHORT XFRecordIndex_;
		BYTE identifier_;
		BYTE level_;
		LargeString name_;
	};
	struct Palette;
	struct UseSelfs;
	struct BoundSheet : public Record
	{
		BoundSheet();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();
		ULONG BOFpos_;
		BYTE visibility_;
		BYTE type_;
		SmallString name_;
	};
	struct Country;
	struct LinkTable;
	struct SharedStringTable : public Record
	{
		SharedStringTable();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();
		ULONG stringsTotal_;
		ULONG uniqueStringsTotal_;
		vector<LargeString> strings_;
	};
	struct ExtSST : public Record
	{
		ExtSST();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();
		USHORT stringsTotal_;
		vector<ULONG> streamPos_;
		vector<USHORT> firstStringPos_;
		vector<USHORT> unused_;
	};
	ULONG Read(const char* data);
	ULONG Write(char* data);
	ULONG DataSize();
	ULONG RecordSize();

	BOF bof_;
	Window1 window1_;
	vector<Font> fonts_;
	vector<XF> XFs_;
	vector<Style> styles_;
	vector<Format> formats_;	//MF
	vector<BoundSheet> boundSheets_;
	SharedStringTable sst_; // shared string table
	ExtSST extSST_;
	YEOF eof_;
};

//MF: exception to handle unexpected YEOF records
struct EXCEPTION_YEOF
{
	EXCEPTION_YEOF(ULONG bytesRead)
	 :	_bytesRead(bytesRead)
	{
	}

	ULONG _bytesRead;
};

//MF
using namespace RefCount;

class Worksheet
{
public:
	Worksheet();

public:
	struct Uncalced;
	struct Index : public Record
	{
		Index();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG DataSize();
		virtual ULONG RecordSize();
		ULONG unused1_;
		size_t firstUsedRowIndex_;
		size_t firstUnusedRowIndex_;
		ULONG unused2_;
		vector<ULONG> DBCellPos_;
	};
	struct CalculationSettings
	{
		struct CalcCount;
		struct CalcMode;
		struct RefMode;
		struct Delta;
		struct Iteration;
		struct SafeRecalc;
	};
	struct PrintHeaders;
	struct PrintGridlines;
	struct Gridset;
	struct Guts;
	struct DefaultRowHeight;
	struct WSBool;
	struct PageSettings
	{
		struct Header;
		struct Footer;
		struct HCenter;
		struct VCenter;
		struct LeftMargin;
		struct RightMargin;
		struct TopMargin;
		struct BottomMargin;
		struct PLS;
		struct Setup;
	};
	struct WorksheetProtection;
	struct DefColWidth;
	struct ColInfo : public Record
	{
		ColInfo();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		USHORT firstColumnIndex_;
		USHORT lastColumnIndex_;
		USHORT columnWidth_;
		USHORT XFRecordIndex_;
		USHORT options_;
		USHORT unused_;
	};
	struct Sort;
	struct ColInfos : public Record
	{
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		virtual ULONG RecordSize();
		vector<ColInfo> colinfo_;
	};
	struct Dimensions : public Record
	{
		Dimensions();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		ULONG firstUsedRowIndex_;
		ULONG lastUsedRowIndexPlusOne_;
		USHORT firstUsedColIndex_;
		USHORT lastUsedColIndexPlusOne_;
		USHORT unused_;
	};
	struct CellTable
	{
		struct RowBlock
		{
			struct Row : public Record
			{
				Row();
				virtual ULONG Read(const char* data);
				virtual ULONG Write(char* data);
				USHORT rowIndex_;
				USHORT firstCellColIndex_;
				USHORT lastCellColIndexPlusOne_;
				USHORT height_;
				USHORT unused1_;
				USHORT unused2_;
				ULONG options_;
			};

			struct CellBlock : public RefCnt
			{
				struct Blank : public Record
				{
					Blank();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					USHORT rowIndex_;
					USHORT colIndex_;
					USHORT XFRecordIndex_;
				};
				struct BoolErr : public Record
				{
					BoolErr();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					USHORT rowIndex_;
					USHORT colIndex_;
					USHORT XFRecordIndex_;
					BYTE value_;
					BYTE error_;
				};
				struct LabelSST : public Record
				{
					LabelSST();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					USHORT rowIndex_;
					USHORT colIndex_;
					USHORT XFRecordIndex_;
					size_t SSTRecordIndex_; // shared string table index
				};
				struct MulBlank : public Record
				{
					MulBlank();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					virtual ULONG DataSize();
					virtual ULONG RecordSize();
					USHORT rowIndex_;
					USHORT firstColIndex_;
					vector<USHORT> XFRecordIndices_;
					USHORT lastColIndex_;
				};
				struct MulRK : public Record
				{
					MulRK();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					virtual ULONG DataSize();
					virtual ULONG RecordSize();
					struct XFRK
					{
						XFRK();
						void Read(const char* data);
						void Write(char* data);
						USHORT XFRecordIndex_;
						LONG RKValue_;
					};
					USHORT rowIndex_;
					USHORT firstColIndex_;
					vector<XFRK> XFRK_;
					USHORT lastColIndex_;
				};
				struct Number : public Record
				{
					Number();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					USHORT rowIndex_;
					USHORT colIndex_;
					USHORT XFRecordIndex_;
					double value_;

				private:
					union
					{
						LONGINT intvalue_;
						double doublevalue_;
					} intdouble_;
				};
				struct RK : public Record
				{
					RK();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					USHORT rowIndex_;
					USHORT colIndex_;
					USHORT XFRecordIndex_;
					ULONG value_;
				};

				struct Formula : public Record
				{
					struct Array : public Record
					{
						Array();
						virtual ULONG Read(const char* data);
						virtual ULONG Write(char* data);
						virtual ULONG DataSize();
						virtual ULONG RecordSize();
						USHORT firstRowIndex_;
						USHORT lastRowIndex_;
						BYTE firstColIndex_;
						BYTE lastColIndex_;
						USHORT options_;
						ULONG unused_;
						vector<char> formula_;
					};
					struct ShrFmla : public Record
					{
						ShrFmla();
						virtual ULONG Read(const char* data);
						virtual ULONG Write(char* data);
						virtual ULONG DataSize();
						virtual ULONG RecordSize();
						USHORT firstRowIndex_;
						USHORT lastRowIndex_;
						BYTE firstColIndex_;
						BYTE lastColIndex_;
						USHORT unused_;
						vector<char> formula_;
					};
					struct ShrFmla1 : public Record
					{
						ShrFmla1();
						virtual ULONG Read(const char* data);
						virtual ULONG Write(char* data);
						virtual ULONG DataSize();
						virtual ULONG RecordSize();
						USHORT firstRowIndex_;
						USHORT lastRowIndex_;
						BYTE firstColIndex_;
						BYTE lastColIndex_;
						USHORT unused_;
						vector<char> formula_;
					};
					struct Table : public Record
					{
						Table();
						virtual ULONG Read(const char* data);
						virtual ULONG Write(char* data);
						USHORT firstRowIndex_;
						USHORT lastRowIndex_;
						BYTE firstColIndex_;
						BYTE lastColIndex_;
						USHORT options_;
						USHORT inputCellRowIndex_;
						USHORT inputCellColIndex_;
						USHORT inputCellColumnInputRowIndex_;
						USHORT inputCellColumnInputColIndex_;
					};
					struct String : public Record
					{
						String();
						~String();
						virtual ULONG Read(const char* data);
						virtual ULONG Write(char* data);
						virtual ULONG DataSize();
						virtual ULONG RecordSize();
						bool empty() {return !wstr_;}
						void Reset();
						char flag_;				// 0 = compressed unicode string  1 = uncompressed unicode string
						// From BIFF8 on, strings are always stored using UTF-16LE text encoding, optionally compressed (see compressed field)
						wchar_t* wstr_;
					};

					Formula();
					virtual ULONG Read(const char* data);
					virtual ULONG Write(char* data);
					virtual ULONG DataSize();
					virtual ULONG RecordSize();
					USHORT rowIndex_;
					USHORT colIndex_;
					USHORT XFRecordIndex_;
					BYTE result_[8];			// formula result (IEEE 754 floating-point value, 64-bit double precision or other special values)
					USHORT options_; 			// 1 = Recalculate always  2 = Calculate on open  8 = Part of a shared formula
					ULONG unused_;				// chn field
					vector<char> RPNtoken_;		// 2 length bytes, followed by a variable length structure
					USHORT type_;

					Array array_;
					ShrFmla shrfmla_;
					ShrFmla1 shrfmla1_;
					Table table_;
					String string_;
				};

				CellBlock();
				~CellBlock();

				void Reset();
				void SetType(int type);

				ULONG Read(const char* data);
				ULONG Write(char* data);
				ULONG DataSize();
				ULONG RecordSize();
				USHORT RowIndex();
				USHORT ColIndex();
				USHORT LastColIndex();
				SHORT type_;

				//MF
				union CellBlockUnion {
					void* void_;
					Blank* blank_;
					MulBlank* mulblank_;
					BoolErr* boolerr_;
					LabelSST* labelsst_;
					MulRK* mulrk_;
					Number* number_;
					RK* rk_;
					Formula* formula_;
				} _union;
			};
			struct DBCell : public Record
			{
				DBCell();
				virtual ULONG Read(const char* data);
				virtual ULONG Write(char* data);
				virtual ULONG DataSize();
				virtual ULONG RecordSize();
				ULONG firstRowOffset_;
				vector<USHORT> offsets_;
			};

			ULONG Read(const char* data);
			ULONG Write(char* data);
			ULONG DataSize();
			ULONG RecordSize();

			vector<Row> rows_;
			vector<SmartPtr<CellBlock> > cellBlocks_;
			DBCell dbcell_;
		};
		ULONG Read(const char* data);
		ULONG Write(char* data);
		ULONG DataSize();
		ULONG RecordSize();

		vector<RowBlock> rowBlocks_;
	};
	struct Window2 : public Record
	{
		Window2();
		virtual ULONG Read(const char* data);
		virtual ULONG Write(char* data);
		USHORT options_;
		USHORT firstVisibleRowIndex_;
		USHORT firstVisibleColIndex_;
		USHORT gridLineColourIndex_;
		USHORT unused1_;
		USHORT magnificationFactorPageBreakPreview_;
		USHORT magnificationFactorNormalView_;
		ULONG unused2_;
	};
	struct SCL;
	struct Pane;
	struct Selection;
	struct MergedCells
	{
		struct MergedCell
		{
			MergedCell();
			virtual ULONG Read(const char* data);
			virtual ULONG Write(char* data);
			ULONG DataSize();
			ULONG RecordSize();
			USHORT firstRow_;
			USHORT lastRow_;
			USHORT firstColumn_;
			USHORT lastColumn_;
		};

		ULONG Read(const char* data);
		ULONG Write(char* data);
		ULONG DataSize();
		ULONG RecordSize();

		vector<MergedCell> mergedCellsVector_;
	};
	struct LabelRanges;
	struct ConditionalFormattingTable;
	struct HyperlinkTable;
	struct SheetLayout;
	struct SheetProtection;
	struct RangeProtection;

	ULONG Read(const char* data);
	ULONG Write(char* data);
	ULONG DataSize();
	ULONG RecordSize();

	BOF bof_;
	Index index_;
	ColInfos colinfos_;
	Dimensions dimensions_;
	CellTable cellTable_;
	Window2 window2_;
	MergedCells mergedCells_;
	YEOF eof_;
};

double GetDoubleFromRKValue(LONG rkValue);	///< Convert a rk value to a double.
int GetIntegerFromRKValue(LONG rkValue); 	///< Convert a rk value to an integer.
LONG GetRKValueFromDouble(double value); 	///< Convert a double to a rk value.
LONG GetRKValueFromInteger(int value);		///< Convert an integer to a rk value.
bool CanStoreAsRKValue(double value);		///< Returns true if the supplied double can be stored as a rk value.

// Forward declarations
class oExcel;
class oExcelWorksheet;
class oExcelCell;

/*******************************************************************************************************/
/*						   Actual classes to read and write to Excel files							   */
/*******************************************************************************************************/
public ref class oExcel
{
public:
	oExcel();
	oExcel(const char* filename);
	~oExcel();

public: // File functions.
	void New(int sheets=3); ///< Create a new Excel workbook with a given number of spreadsheets (Minimum 1).
	bool Load(const char* filename);	///< Load an Excel workbook from a file.
	bool Load(const wchar_t* filename);	///< Load an Excel workbook from a file.
	bool Save();	///< Save current Excel workbook to opened file.
	bool SaveAs(const char* filename);	///< Save current Excel workbook to a file.
	bool SaveAs(const wchar_t* filename);	///< Save current Excel workbook to a file.
	void Close();

public: // Worksheet functions.
	int GetTotalWorkSheets();	///< Total number of Excel worksheets in current Excel workbook.

	oExcelWorksheet* GetWorksheet(int sheetIndex);	///< Get a pointer to an Excel worksheet at the given index. Index starts from 0. Returns 0 if index is invalid.
	oExcelWorksheet* GetWorksheet(const char* name);	///< Get a pointer to an Excel worksheet that has given ANSI name. Returns 0 if there is no Excel worksheet with the given name.
	oExcelWorksheet* GetWorksheet(const wchar_t* name); ///< Get a pointer to an Excel worksheet that has given Unicode name. Returns 0 if there is no Excel worksheet with the given name.

	oExcelWorksheet* AddWorksheet(int sheetIndex=-1);	///< Add a new Excel worksheet to the given index. Name given to worksheet is SheetX, where X is a number which starts from 1. Index starts from 0. Worksheet is added to the last position if sheetIndex == -1. Returns a pointer to the worksheet if successful, 0 if otherwise.
	oExcelWorksheet* AddWorksheet(const char* name, int sheetIndex=-1); ///< Add a new Excel worksheet with given ANSI name to the given index. Index starts from 0. Worksheet is added to the last position if sheetIndex == -1. Returns a pointer to the worksheet if successful, 0 if otherwise.
	oExcelWorksheet* AddWorksheet(const wchar_t* name, int sheetIndex=-1);	///< Add a new Excel worksheet with given Unicode name to the given index. Index starts from 0. Worksheet is added to the last position if sheetIndex == -1. Returns a pointer to the worksheet if successful, 0 if otherwise.

	bool DeleteWorksheet(int sheetIndex);		///< Delete an Excel worksheet at the given index. Index starts from 0. Returns true if successful, false if otherwise.
	bool DeleteWorksheet(const char* name); 	///< Delete an Excel worksheet that has given ANSI name. Returns true if successful, false if otherwise.
	bool DeleteWorksheet(const wchar_t* name);	///< Delete an Excel worksheet that has given Unicode name. Returns true if successful, false if otherwise.

	char* GetAnsiSheetName(int sheetIndex);			///< Get the worksheet name at the given index. Index starts from 0. Returns 0 if name is in Unicode format.
	wchar_t* GetUnicodeSheetName(int sheetIndex);	///< Get the worksheet name at the given index. Index starts from 0. Returns 0 if name is in Ansi format.
	bool GetSheetName(int sheetIndex, char* name);		///< Get the worksheet name at the given index. Index starts from 0. Returns false if name is in Unicode format.
	bool GetSheetName(int sheetIndex, wchar_t* name);	///< Get the worksheet name at the given index. Index starts from 0. Returns false if name is in Ansi format.

	bool RenameWorksheet(int sheetIndex, const char* to);			///< Rename an Excel worksheet at the given index to the given ANSI name. Index starts from 0. Returns true if successful, false if otherwise.
	bool RenameWorksheet(int sheetIndex, const wchar_t* to);	 	///< Rename an Excel worksheet at the given index to the given Unicode name. Index starts from 0. Returns true if successful, false if otherwise.
	bool RenameWorksheet(const char* from, const char* to); 		///< Rename an Excel worksheet that has given ANSI name to another ANSI name. Returns true if successful, false if otherwise.
	bool RenameWorksheet(const wchar_t* from, const wchar_t* to);	///< Rename an Excel worksheet that has given Unicode name to another Unicode name. Returns true if successful, false if otherwise.

private: // Functions to read and write raw Excel format.
	size_t Read(const char* data, size_t dataSize);
	size_t Write(char* data);
	void AdjustStreamPositions();
	void AdjustBoundSheetBOFPositions();
	void AdjustDBCellPositions();
	void AdjustExtSSTPositions();

	enum {WORKBOOK_GLOBALS=0x0005, VISUAL_BASIC_MODULE=0x0006,
		  WORKSHEET=0x0010, CHART=0x0020};

private: // Internal functions
	void UpdateYExcelWorksheet();	///< Update yesheets_ using information from worksheets_.
	void UpdateWorksheets();		///< Update worksheets_ using information from yesheets_.

public:
	CompoundFile file_; 					///< Compound file handler.
	Workbook workbook_; 					///< Raw Workbook.
	vector<Worksheet> worksheets_;			///< Raw Worksheets.
	vector<SmartPtr<oExcelWorksheet> > yesheets_;	///< Parsed Worksheets.
};

class oExcelWorksheet : public RefCount::RefCnt
{
	friend class oExcel;

public:
	oExcelWorksheet(oExcel* excel, int sheetIndex);

public: // Worksheet functions
	char* GetAnsiSheetName();			///< Get the current worksheet name. Returns 0 if name is in Unicode format.
	wchar_t* GetUnicodeSheetName();		///< Get the current worksheet name. Returns 0 if name is in Ansi format.
	bool GetSheetName(char* name);		///< Get the current worksheet name. Returns false if name is in Unicode format.
	bool GetSheetName(wchar_t* name);	///< Get the current worksheet name. Returns false if name is in Ansi format.
	bool Rename(const char* to);		///< Rename current Excel worksheet to another ANSI name. Returns true if successful, false if otherwise.
	bool Rename(const wchar_t* to);		///< Rename current Excel worksheet to another Unicode name. Returns true if successful, false if otherwise.
	void Print(ostream& os, char delimiter=',', char textQualifier='\0')  const; ///< Print entire worksheet to an output stream, separating each column with the defined delimiter and enclosing text using the defined textQualifier. Leave out the textQualifier argument if do not wish to have any text qualifiers.

public: // Cell functions
	int GetTotalRows() const;		///< Total number of rows in current Excel worksheet.
	int GetTotalCols() const;		///< Total number of columns in current Excel worksheet.

	oExcelCell* Cell(int row, int col); ///< Return a pointer to an Excel cell. row and col starts from 0. Returns 0 if row exceeds 65535 or col exceeds 255.
	const oExcelCell* Cell(int row, int col) const; ///< Return a pointer to an Excel cell. row and col starts from 0. Returns 0 if row exceeds 65535 or col exceeds 255.
	bool EraseCell(int row, int col);		///< Erase content of a cell. row and col starts from 0. Returns true if successful, false if row or col exceeds range.

	void SetColWidth(const int colindex , const USHORT colwidth);
	USHORT GetColWidth(const int colindex);

	void MergeCells(int row, int col, USHORT rowRange, USHORT colRange);

private: // Internal functions
	void UpdateCells(); ///< Update cells using information from oExcel.worksheets_.

private:
	oExcel* excel_; 				///< Pointer to instance of oExcel.
	int sheetIndex_; 					///< Index of worksheet in workbook.
	int	maxRows_;						///< Total number of rows in worksheet.
	int	maxCols_;						///< Total number of columns in worksheet.
	vector<vector<oExcelCell> > cells_; ///< Cells matrix.
	Worksheet::ColInfos colInfos_;		/// used to record column info
};

class oExcelCell
{
public:
	oExcelCell();

	enum {UNDEFINED, INT, DOUBLE, STRING, WSTRING, FORMULA/*MF*/};
	int Type() const;					///< Get type of value stored in current Excel cell. Returns one of the above enums.

	bool Get(int& val) const;			///< Get an integer value. Returns false if cell does not contain an integer or a double.
	bool Get(double& val) const;		///< Get a double value. Returns false if cell does not contain a double or an integer.
	size_t GetStringLength() const; 	///< Return length of ANSI or Unicode string (excluding null character).

	int GetInteger() const; 			///< Get an integer value. Returns 0 if cell does not contain an integer.
	double GetDouble() const;			///< Get a double value. Returns 0.0 if cell does not contain a double.
	const char* GetString() const;		///< Get an ANSI string. Returns 0 if cell does not contain an ANSI string.
	const wchar_t* GetWString() const;	///< Get an Unicode string. Returns 0 if cell does not contain an Unicode string.

	friend ostream& operator<<(ostream& os, const oExcelCell& cell);	///< Print cell to output stream. Print a null character if cell is undefined.

	void Set(int val);					///< Set content of current Excel cell to an integer.
	void Set(double val);				///< Set content of current Excel cell to a double.
	void Set(const char* str);			///< Set content of current Excel cell to an ANSI string.
	void Set(const wchar_t* str);		///< Set content of current Excel cell to an Unicode string.

	void SetInteger(int val);			///< Set content of current Excel cell to an integer.
	void SetDouble(double val); 		///< Set content of current Excel cell to a double.
	void SetRKValue(int rkValue);		///< Set content of current Excel cell to a double or integer value.
	void SetString(const char* str);	///< Set content of current Excel cell to an ANSI string.
	void SetWString(const wchar_t* str);///< Set content of current Excel cell to an Unicode string.

	void SetFormula(const Worksheet::CellTable::RowBlock::CellBlock::Formula& f);//MF

	int GetXFormatIdx() const				{return _xf_idx;}	//MF
	void SetXFormatIdx(int xf_idx)			{_xf_idx = xf_idx;} //MF
	void SetFormat(const ExcelFormat::CellFormat& fmt); //MF

	void EraseContents();	///< Erase the content of current Excel cell. Set type to UNDEFINED.

	USHORT GetMergedRows() const				{return mergedRows_;}
	USHORT GetMergedColumns() const				{return mergedColumns_;}

	void SetMergedRows(USHORT mergedRows)		{mergedRows_ = mergedRows;}
	void SetMergedColumns(USHORT mergedColumns)	{mergedColumns_ = mergedColumns;}

private:
	int type_;							///< Type of value stored in current Excel cell. Contains one of the above enums.
	int ival_;							///< Integer value stored in current Excel cell.
	double dval_;						///< Double value stored in current Excel cell.
	vector<char> str_;					///< ANSI string stored in current Excel cell. Include null character.
	vector<wchar_t> wstr_;				///< Unicode string stored in current Excel cell. Include null character.
										
	USHORT mergedRows_;					///< Number of rows merged to this cell. 1 means only itself.
	USHORT mergedColumns_;				///< Number of columns merged to this cell. 1 means only itself.

	bool Get(char* str) const;			///< Get an ANSI string. Returns false if cell does not contain an ANSI string.
	bool Get(wchar_t* str) const;		///< Get an Unicode string. Returns false if cell does not contain an Unicode string.

	//MF extensions for formating and formulas ...

	int _xf_idx;			//MF

	friend class oExcel;
	friend class oExcelWorksheet; // for Get(w/char*);

	struct Formula : public RefCount::RefCnt
	{
		Formula(const Worksheet::CellTable::RowBlock::CellBlock::Formula& f);

		int _formula_type;
		vector<char> _formula;
		unsigned char _result[8];	// formula result (IEEE 754 floating-point value, 64-bit double precision or other special values)
		std::wstring wstr_;			// formula result in case of strings, stored as UTF-16LE string
		std::string str_;			// formula result in case of strings, stored as ANSI string

		//shrfmla1_
		USHORT	firstRowIndex_;
		USHORT	lastRowIndex_;
		char	firstColIndex_;
		char	lastColIndex_;
		USHORT	unused_;
		vector<char> shrformula_;
	};

	SmartPtr<Formula> _pFormula;

	bool get_formula(Worksheet::CellTable::RowBlock::CellBlock* pCell) const;
};


}


}
