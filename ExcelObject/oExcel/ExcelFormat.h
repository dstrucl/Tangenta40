
#ifndef EXCELFORMAT_H
#define EXCELFORMAT_H

 // pattern constants
public enum class COLOR1_PAT:unsigned  {
	COLOR1_PAT_EMPTY		= 0x00000000,
	COLOR1_PAT_SOLID		= 0x04000000,
	COLOR1_PAT_2			= 0x08000000,
	COLOR1_PAT_3			= 0x0C000000,
	COLOR1_PAT_4			= 0x10000000,
	COLOR1_PAT_5			= 0x14000000,
	COLOR1_PAT_6			= 0x18000000,
	COLOR1_PAT_7			= 0x1C000000,
	COLOR1_PAT_8			= 0x20000000,
	COLOR1_PAT_9			= 0x24000000,
	COLOR1_PAT_10			= 0x28000000,
	COLOR1_PAT_11			= 0x2C000000,
	COLOR1_PAT_12			= 0x30000000,
	COLOR1_PAT_13			= 0x34000000,
	COLOR1_PAT_14			= 0x38000000,
	COLOR1_PAT_15			= 0x3C000000,
	COLOR1_PAT_16			= 0x40000000,
	COLOR1_PAT_17			= 0x44000000,
	COLOR1_PAT_18			= 0x48000000
};

 // line style constants
public enum class EXCEL_LS:char {
	EXCEL_LS_NO_LINE					= 0x00,
	EXCEL_LS_THIN						= 0x01,
	EXCEL_LS_MEDIUM						= 0x02,
	EXCEL_LS_DASHED						= 0x03,
	EXCEL_LS_DOTTED						= 0x04,
	EXCEL_LS_THICK						= 0x05,
	EXCEL_LS_DOUBLE						= 0x06,
	EXCEL_LS_HAIR						= 0x07,
	EXCEL_LS_MEDIUM_DASHED				= 0x08,
	EXCEL_LS_THIN_DASH_DOTTED			= 0x09,
	EXCEL_LS_MEDIUM_DASH_DOTTED			= 0x0A,
	EXCEL_LS_THIN_DASH_DOT_DOTTED		= 0x0B,
	EXCEL_LS_MEDIUM_DASH_DOT_DOTTED		= 0x0C,
	EXCEL_LS_SLANTED_MEDIUM_DASH_DOTTED	= 0x0D
};

 // Font option flags
public enum class EXCEL_FONT_OPTIONS:short {
	EXCEL_FONT_OPTIONS_NONE = 0x00,
	EXCEL_FONT_BOLD			= 0x01,	// redundant in BIFF5-BIFF8, see oExcelFont::_weight
	EXCEL_FONT_ITALIC		= 0x02,
	EXCEL_FONT_UNDERLINED	= 0x04,	// redundant in BIFF5-BIFF8, see oExcelFont::_underline_type
	EXCEL_FONT_STRUCK_OUT	= 0x08,
	EXCEL_FONT_OUTLINED		= 0x10,
	EXCEL_FONT_SHADOWED		= 0x20,
	EXCEL_FONT_CONDENSED	= 0x40,
	EXCEL_FONT_EXTENDED		= 0x80
};

 // Font escapement types
public enum class EXCEL_ESCAPEMENT:short {
	EXCEL_ESCAPEMENT_NONE		 = 0,
	EXCEL_ESCAPEMENT_SUPERSCRIPT = 1,
	EXCEL_ESCAPEMENT_SUBSCRIPT	 = 2
};

 // Font underline types
public enum class EXCEL_UNDERLINE_FLAGS:char {
	EXCEL_UNDERLINE_NONE				= 0x00,
	EXCEL_UNDERLINE_SINGLE				= 0x01,
	EXCEL_UNDERLINE_DOUBLE				= 0x02,
	EXCEL_UNDERLINE_SINGLE_ACCOUNTING	= 0x21,
	EXCEL_UNDERLINE_DOUBLE_ACCOUNTING	= 0x22
};

 // Excel font family constants, see also FF_DONTCARE, ... in wingdi.h
public enum class EXCEL_FONT_FAMILY:char {
	EXCEL_FONT_FAMILY_DONTCARE	 = 0,
	EXCEL_FONT_FAMILY_ROMAN		 = 1,
	EXCEL_FONT_FAMILY_SWISS		 = 2,
	EXCEL_FONT_FAMILY_MODERN	 = 3,
	EXCEL_FONT_FAMILY_SCRIPT	 = 4,
	EXCEL_FONT_FAMILY_DECORATIVE = 5
};

/*
 Bit Mask Contents of alignment byte
 2- 0 07H XF_HOR_ALIGN: Horizontal alignment
 3    08H 1 = Text is wrapped at right border
 6- 4 70H XF_VERT_ALIGN: Vertical alignment
 7    80H 1 = Justify last line in justified or distibuted text
*/
public enum class EXCEL_ALIGNMENT:unsigned char {
	 // horizontal aligmment
	EXCEL_HALIGN_GENERAL		= 0x00,
	EXCEL_HALIGN_LEFT			= 0x01,
	EXCEL_HALIGN_CENTRED		= 0x02,
	EXCEL_HALIGN_RIGHT			= 0x03,
	EXCEL_HALIGN_FILLED			= 0x04,
	EXCEL_HALIGN_JUSITFIED		= 0x05,
	EXCEL_HALIGN_SEL_CENTRED	= 0x06,	// centred across selection
	EXCEL_HALIGN_DISTRIBUTED	= 0x07,	// available in Excel 10.0 (Excel XP) and later only

	 // vertical alignment
	EXCEL_VALIGN_TOP			= 0x00,
	EXCEL_VALIGN_CENTRED		= 0x10,
	EXCEL_VALIGN_BOTTOM			= 0x20,
	EXCEL_VALIGN_JUSTIFIED		= 0x30,
	EXCEL_VALIGN_DISTRIBUTED	= 0x40,	// available in Excel 10.0 (Excel XP) and later only

	EXCEL_JUSTIFY_LAST_LINE		= 0x80	// justify last line in justified or distibuted text
};

#include <float.h>
#include "oExcel.hpp"

namespace ExcelFormat 
{

using namespace YExcel;
using namespace System;



#define XLS_FORMAT_GENERAL		L"General"
#define XLS_FORMAT_TEXT			L"@"
#define XLS_FORMAT_INTEGER		L"0"
#define XLS_FORMAT_DECIMAL		L"0.00"
#define XLS_FORMAT_PERCENT		L"0%"
#define XLS_FORMAT_DATE			L"M/D/YY"
#define XLS_FORMAT_TIME			L"h:mm:ss"
#define XLS_FORMAT_DATETIME		L"M/D/YY h:mm"

#define XLS_FORMAT_TIME_H		L"[h]:mm:ss"

#define	FIRST_USER_FORMAT_IDX	164




struct oExcelFont
{
public:
 //	oExcelFont()
	//{
	// 	_height = 200;
	//	_options = (EXCEL_FONT_OPTIONS::EXCEL_FONT_OPTIONS_NONE);
	//	_color_index = (0x7FFF);
	//	_weight = (400); // FW_NORMAL
	//	_escapement_type = (EXCEL_ESCAPEMENT::EXCEL_ESCAPEMENT_NONE);
	//	_underline_type = (EXCEL_UNDERLINE_FLAGS::EXCEL_UNDERLINE_NONE);
	//	_font_family = (EXCEL_FONT_FAMILY::EXCEL_FONT_FAMILY_DONTCARE);
	//	_character_set = 0; // ANSI_CHARSET
	//	_name = L"Arial";
	//}

	oExcelFont()
	 :	_height(200),
		_options(EXCEL_FONT_OPTIONS::EXCEL_FONT_OPTIONS_NONE),
		_color_index(0x7FFF),
		_weight(400), // FW_NORMAL
		_escapement_type(EXCEL_ESCAPEMENT::EXCEL_ESCAPEMENT_NONE),
		_underline_type(EXCEL_UNDERLINE_FLAGS::EXCEL_UNDERLINE_NONE),
		_font_family(EXCEL_FONT_FAMILY::EXCEL_FONT_FAMILY_DONTCARE),
		_character_set(0), // ANSI_CHARSET
		_name(L"Arial")
	{
	}

	oExcelFont(const Workbook::Font& font)
	 :	_height(font.height_),
		_options(font.options_),
		_color_index(font.colourIndex_),
		_weight(font.weight_),
		_escapement_type(font.escapementType_),
		_underline_type(font.underlineType_),
		_font_family(font.family_),
		_character_set(font.characterSet_),
		_name(wstringFromSmallString(font.name_))
	{
	}

	wstring	_name;
	short	_height;			// font height in twips (1/20 of a point)
	short	_weight;			// FW_NORMAL, FW_BOLD, ...
	EXCEL_FONT_OPTIONS	_options;			// see EXCEL_FONT_OPTIONS
	short	_color_index;		// font colour index
	EXCEL_ESCAPEMENT	_escapement_type;	// see EXCEL_ESCAPEMENT
	EXCEL_UNDERLINE_FLAGS	_underline_type;	// see EXCEL_UNDERLINE_FLAGS
	EXCEL_FONT_FAMILY	_font_family;		// see EXCEL_FONT_FAMILY
	char	_character_set;		// ANSI_CHARSET, DEFAULT_CHARSET, SYMBOL_CHARSET, ...

	oExcelFont& set_height(int height)
	{
		_height = height;
		return *this;
	}

	oExcelFont& set_weight(int weight)
	{
		_weight = weight;
		return *this;
	}

	oExcelFont& set_italic(bool italic)
	{
		short excel_font_italic = (short)EXCEL_FONT_OPTIONS::EXCEL_FONT_ITALIC;
		_options = (EXCEL_FONT_OPTIONS)((((short)_options)&~excel_font_italic) | (short)(italic? excel_font_italic: 0));
		return *this;
	}

	oExcelFont& set_color_index(int color_idx)
	{
		_color_index = color_idx;
		return *this;
	}

	oExcelFont& set_underline_type(EXCEL_UNDERLINE_FLAGS underline_type)
	{
		_underline_type = underline_type;
		return *this;
	}

	oExcelFont& set_escapement(EXCEL_ESCAPEMENT escapement_type)
	{
		_escapement_type = escapement_type;
		return *this;
	}

	oExcelFont& set_font_name(const wchar_t* name)
	{
		_name = name;
		return *this;
	}

	bool matches(const Workbook::Font& font) const
	{
		if (wstringFromSmallString(font.name_) != _name)
			return false;

		if (font.height_ != _height)
			return false;

		if (font.weight_ != _weight)
			return false;

		if (font.options_ != _options)
			return false;

		if (font.colourIndex_ != _color_index)
			return false;

		if (font.escapementType_ != _escapement_type)
			return false;

		if (font.underlineType_ != _underline_type)
			return false;

		if (font.family_ != _font_family)
			return false;

		if (font.characterSet_ != _character_set)
			return false;

		return true;
	}
};


struct ExcelFormat::oCellFormat;

 // Excel cell format manager class
class oXLSFormatManager
{
public:

	void InitializePredefinedFormats();

	oXLSFormatManager(oExcel& xls);

	oXLSFormatManager(oExcel *pxls);

	const Workbook::Font& get_font(const oCellFormat& fmt) const;
	wstring get_format_string(const oCellFormat& fmt) const;
	const Workbook::XF& get_XF(int xf_idx) const {return p_xls->workbook_.XFs_[xf_idx];}

	int get_font_idx(const oExcelFont& font);
	int get_format_idx(const wstring& fmt_str);
	int get_xf_idx(const oCellFormat& fmt);

private:
	oExcel *p_xls;

	int _next_fmt_idx;

	typedef map<int, wstring> FormatMap;
	typedef map<wstring, int> FormatRevMap;
	FormatMap _formats;
	FormatRevMap _formats_rev;
};


enum XF_USED_ATTRIB {
	XF_USED_ATTRIB_NUMBER_FORMAT	= 0x01,
	XF_USED_ATTRIB_FONT				= 0x02,
	XF_USED_ATTRIB_ALIGN			= 0x04,	// horizontal and vertical alignment, text wrap, indentation, orientation, rotation, and text direction
	XF_USED_ATTRIB_BORDER_LINES		= 0x08,
	XF_USED_ATTRIB_BKGND_AREA_STYLE	= 0x10,
	XF_USED_ATTRIB_CELL_PROTECTION	= 0x20
};




/*
Indentation, shrink to cell size, and text direction:
 Bit Mask Contents
 3- 0 0FH Indent level
 4    10H 1 = Shrink content to fit into cell
 7- 6 C0H Text direction: 0 = According to context; 1 = Left-to-right; 2 = Right-to-left
*/
#define MAKE_TEXT_PROPS(indent, flags)	((indent) | (flags))

enum EXCEL_TEXT_PROP_FLAGS {
	 // shrink flag
	EXCEL_TEXT_PROP_SHRINK			= 0x10,

	 // text direction
	EXCEL_TEXT_PROP_DEFAULT			= 0x00,
	EXCEL_TEXT_PROP_LEFT_TO_RIGHT	= 0x40,
	EXCEL_TEXT_PROP_RIGHT_TO_LEFT	= 0x80
};


/*
  Bit      Mask Contents of cell border lines and background area:
 3- 0 0000000FH Left line style
 7- 4 000000F0H Right line style
11- 8 00000F00H Top line style
15-12 0000F000H Bottom line style
22-16 007F0000H Color index for left line colour
29-23 3F800000H Color index for right line colour
30    40000000H 1 = Diagonal line from top left to right bottom
31    80000000H 1 = Diagonal line from bottom left to right top
*/
#define MAKE_BORDERSTYLE(left, right, top, bottom, lcol, rcol) \
	((left) | ((right)<<4) | ((top)<<8) | ((bottom)<<12) | ((lcol)<<16) | ((rcol)<<23))


 // borderline flags for diagonal lines
enum BORDERLINE_FLAGS {
	BORDERLINE_DIAG1	= 0x40000000,
	BORDERLINE_DIAG2	= 0x80000000
};


/*
  Bit      Mask Contents of COLOR1
06- 0 0000007FH Color index for top line colour
13- 7 00003F80H Color index for bottom line colour
20-14 001FC000H Color index for diagonal line colour
24-21 01E00000H Diagonal line style
31-26 FC000000H Fill pattern
*/
#define MAKE_COLOR1(top, bottom, diag, pat)	((top) | ((bottom)<<7) | ((diag)<<14) | pat)

 // line style constants for COLOR1
public enum class COLOR1_LS:unsigned { // EXCEL_LS << 21
	COLOR1_LS_NO_LINE						= 0x0000000,
	COLOR1_LS_THIN							= 0x0200000,
	COLOR1_LS_MEDIUM						= 0x0400000,
	COLOR1_LS_DASHED						= 0x0600000,
	COLOR1_LS_DOTTED						= 0x0800000,
	COLOR1_LS_THICK							= 0x0A00000,
	COLOR1_LS_DOUBLE						= 0x0C00000,
	COLOR1_LS_HAIR							= 0x0E00000,
	COLOR1_LS_MEDIUM_DASHED					= 0x1000000,
	COLOR1_LS_THIN_DASH_DOTTED				= 0x1200000,
	COLOR1_LS_MEDIUM_DASH_DOTTED			= 0x1400000,
	COLOR1_LS_THIN_DASH_DOT_DOTTED			= 0x1600000,
	COLOR1_LS_MEDIUM_DASH_DOT_DOTTED		= 0x1800000,
	COLOR1_LS_SLANTED_MEDIUM_DASH_DOTTED	= 0x1A00000
};


/*
   Bit Mask Contents of COLOR2
 6- 0 007FH Color index for pattern colour
13- 7 3F80H Color index for pattern background
*/
#define MAKE_COLOR2(pc, pbc)	((pc) | ((pbc)<<7))


 // predefined Excel color definitions
public enum class EXCEL_COLORS {
	EGA_BLACK	= 0,	// 000000H
	EGA_WHITE	= 1,	// FFFFFFH
	EGA_RED		= 2,	// FF0000H
	EGA_GREEN	= 3,	// 00FF00H
	EGA_BLUE	= 4,	// 0000FFH
	EGA_YELLOW	= 5,	// FFFF00H
	EGA_MAGENTA	= 6,	// FF00FFH
	EGA_CYAN	= 7		// 00FFFFH
};


 // Excel cell format
struct oCellFormat
{
public:
	oCellFormat(oXLSFormatManager& mgr)
	 :	_mgr(mgr)
	{
		init();
	}

	oCellFormat(oXLSFormatManager *pmgr)
	 :	_mgr(*pmgr)
	{
		init();
	}

	oCellFormat(oXLSFormatManager& mgr, const oExcelFont& font)
	 :	_mgr(mgr)
	{
		init();
		set_font(font);
	}

	oCellFormat(oXLSFormatManager *pmgr, const oExcelFont& font)
	 :	_mgr(*pmgr)
	{
		init();
		set_font(font);
	}


	oCellFormat(oXLSFormatManager& mgr, const Workbook::XF& xf, int xf_idx)
	 :	_mgr(mgr)
	{
		init(xf, xf_idx);
	}

	oCellFormat(oXLSFormatManager *pmgr, const Workbook::XF& xf, int xf_idx)
	 :	_mgr(*pmgr)
	{
		init(xf, xf_idx);
	}


	oCellFormat(oXLSFormatManager& mgr, const oExcelCell* cell)
	 :	_mgr(mgr)
	{
		int xf_idx = cell->GetXFormatIdx();
		init(mgr.get_XF(xf_idx), xf_idx);
	}

	oXLSFormatManager& get_format_manager() const
	{
		return _mgr;
	}

	 // return XF index for all current attributes
	int get_xf_idx() const
	{
		if (_xf_idx == -1)
			_xf_idx = _mgr.get_xf_idx(*this);

		return _xf_idx;
	}

	void flush()
	{
		_xf_idx = -1;	// invalidate XF index
	}

	int get_font_idx() const
	{
		return _font_idx;
	}

	int get_fmt_idx() const
	{
		return _fmt_idx;
	}

	oExcelFont get_font()
	{
		return oExcelFont(_mgr.get_font(*this));
	}
	oCellFormat& set_font(const oExcelFont& font)
	{
		_font_idx = _mgr.get_font_idx(font);
		flush();
		return *this;
	}

	wstring get_format_string() const
	{
		return _mgr.get_format_string(*this);
	}
	oCellFormat& set_format_string(const char* fmt_str)
	{
		return set_format_string(widen_string(fmt_str));
	}
	oCellFormat& set_format_string(const wstring& fmt_str)
	{
		_fmt_idx = _mgr.get_format_idx(fmt_str);
		flush();
		return *this;
	}

	int get_color1() const
	{
		return _color1;
	}
	oCellFormat& set_color1(unsigned color)
	{
		_color1 = color;
		flush();
		return *this;
	}

	unsigned short get_color2() const
	{
		return _color2;
	}
	oCellFormat& set_color2(unsigned short color)
	{
		_color2 = color;
		flush();
		return *this;
	}

	 // convenience function to set color1 and color2 at the same time
	oCellFormat& set_background(unsigned short color2, unsigned color1= (unsigned) COLOR1_PAT::COLOR1_PAT_SOLID)
	{
		return set_color1(color1).set_color2(color2);
	}

	EXCEL_ALIGNMENT get_alignment() const
	{
		return _alignment;
	}
	oCellFormat& set_alignment(EXCEL_ALIGNMENT alignment)
	{
		_alignment = alignment;
		flush();
		return *this;
	}

	bool is_wrapping()
	{
		return ( ((char)_alignment) & 0x08)? true: false;
	}
	oCellFormat& set_wrapping(bool wrap)
	{
		return set_alignment((EXCEL_ALIGNMENT)((((char)_alignment)&~0x08) | (wrap? 0x08: 0x00)));
	}

	char get_rotation() const
	{
		return _rotation;
	}
	oCellFormat& set_rotation(char rotation)
	{
		_rotation = rotation;
		flush();
		return *this;
	}

	char get_text_props() const
	{
		return _text_props;
	}
	oCellFormat& set_text_props(char text_props)
	{
		_text_props = text_props;
		flush();
		return *this;
	}

	int get_borderlines() const
	{
		return _borderlines;
	}
	oCellFormat& set_borderlines(int borderlines)
	{
		_borderlines = borderlines;
		flush();
		return *this;
	}

	 // set borderlines using EXCEL_LS enumeration constants and colour indices
	oCellFormat& set_borderlines(
		EXCEL_LS left, EXCEL_LS right, EXCEL_LS top, EXCEL_LS bottom,
		unsigned idxLclr, unsigned idxRclr
	)
	{
		int xleft = (int) left;
		int xright = (int) right; 
		int xtop = (int) top;
		int xbottom = (int) bottom;
		_borderlines = MAKE_BORDERSTYLE(xleft, xright, xtop, xbottom, idxLclr, idxRclr);
		flush();
		return *this;
	}

	 // set borderlines including the top and bottom colour
	oCellFormat& set_borderlines(
		EXCEL_LS left, EXCEL_LS right, EXCEL_LS top, EXCEL_LS bottom,
		unsigned idxLclr, unsigned idxRclr, unsigned idxTclr, unsigned idxBclr,
		EXCEL_LS diag,		// diagonal line style
		COLOR1_PAT pattern	// fill pattern
	)
	{
		int xleft = (int) left;
		int xright = (int) right; 
		int xtop = (int) top;
		int xbottom = (int) bottom;
		int xdiag = (int) diag;
		int xpattern = (int) pattern;
		

		_borderlines = MAKE_BORDERSTYLE(xleft, xright, xtop, xbottom, idxLclr, idxRclr);
		_color1 = MAKE_COLOR1(idxTclr, idxBclr, xdiag, xpattern);
		flush();
		return *this;
	}

	bool matches(const Workbook::XF& xf) const
	{
		if (xf.fontRecordIndex_ != _font_idx)
			return false;

		if (xf.formatRecordIndex_ != _fmt_idx)
			return false;

		if (xf.alignment_ != _alignment)
			return false;

		if (xf.rotation_ != _rotation)
			return false;

		if (xf.textProperties_ != _text_props)
			return false;

		if (xf.borderLines_ != _borderlines)
			return false;

		if (xf.colour1_ != _color1)
			return false;

		if (xf.colour2_ != _color2)
			return false;

		return true;
	}

	void get_xf(Workbook::XF& xf) const
	{
		xf.fontRecordIndex_ = _font_idx;
		xf.formatRecordIndex_ = _fmt_idx;
		xf.alignment_ = _alignment;
		xf.rotation_= _rotation;
		xf.textProperties_= _text_props;
		xf.borderLines_= _borderlines;
		xf.colour1_ = _color1;
		xf.colour2_ = _color2;
	}

	oXLSFormatManager& _mgr;
private:

	mutable int _xf_idx;	// cached XF index

	int		_font_idx;
	int		_fmt_idx;

//	char	_protectionType;
	EXCEL_ALIGNMENT	_alignment;			// alignment and text break, see EXCEL_ALIGNMENT
	char	_rotation;			// text rotation angle in degrees
	char	_text_props;		// see MAKE_TEXT_PROPS() and EXCEL_TEXT_PROP_FLAGS
//	char	_usedAttributes;
	int		_borderlines;		// see MAKE_BORDERSTYLE(), EXCEL_LS and BORDERLINE_FLAGS
	unsigned _color1;			// see MAKE_COLOR1(), COLOR1_LS and COLOR1_PAT
	unsigned short _color2;		// see MAKE_COLOR2()

	void init()
	{
		_font_idx = 0;
		_fmt_idx = 0;
		_alignment = EXCEL_ALIGNMENT::EXCEL_VALIGN_BOTTOM;
		_rotation = 0;
		_text_props = MAKE_TEXT_PROPS(0, EXCEL_TEXT_PROP_DEFAULT);
		_borderlines = 0;
		_color1 = 0;
		_color2 = MAKE_COLOR2(64, 65); // 0x20C0

		_xf_idx = 0;
	}

	void init(const Workbook::XF& xf, int xf_idx)
	{
		_font_idx = xf.fontRecordIndex_;
		_fmt_idx = xf.formatRecordIndex_;
		_alignment = xf.alignment_;
		_rotation = xf.rotation_;
		_text_props = xf.textProperties_;
		_borderlines = xf.borderLines_;
		_color1 = xf.colour1_;
		_color2 = xf.colour2_;
		_xf_idx = xf_idx;
	}
};

} // namespace ExcelFormat


namespace YExcel {



public ref class XLSFormatManager
{
public:
	class ExcelFormat::oXLSFormatManager * m_oXLSFormatManager;
	XLSFormatManager(Excel ^xls) {
		                          m_oXLSFormatManager = new ExcelFormat::oXLSFormatManager(xls->m_oExcel);
	                             }

};

public value class xls_FORMAT
{
public:
	static System::String  ^GENERAL = XLS_FORMAT_GENERAL;
	static System::String  ^xTEXT = XLS_FORMAT_TEXT;
	static System::String  ^INTEGER = XLS_FORMAT_INTEGER;

	static System::String  ^DECIMAL = XLS_FORMAT_DECIMAL;

	static System::String  ^PERCENT = XLS_FORMAT_PERCENT;
	static System::String  ^DATE  =  XLS_FORMAT_DATE;
	static System::String  ^TIME = XLS_FORMAT_TIME;
	static System::String  ^DATETIME = XLS_FORMAT_DATETIME;
};

public ref class CellFormat
{

public:

	struct ExcelFormat::oCellFormat *m_poCellFormat;

	CellFormat(XLSFormatManager ^xls_mgr) {
		                                   m_poCellFormat = new  ExcelFormat::oCellFormat(xls_mgr->m_oXLSFormatManager);
	                                     }

	void set_format_string(const char* fmt_str)
	{
		m_poCellFormat->set_format_string(fmt_str);
	}


	void set_format_string_INTEGER(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_INTEGER);
	}
	
	void set_format_string_TEXT(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_TEXT);
	}

	void set_format_string_DECIMAL(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_DECIMAL);
	}

	void set_format_string_PERCENT(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_PERCENT);
	}

	void set_format_string_DATE(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_DATE);
	}

	void set_format_string_TIME(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_TIME);
	}

	void set_format_string_TIME_H(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_TIME_H);
	}

	void set_format_string_DATETIME(void)
	{
		m_poCellFormat->set_format_string(XLS_FORMAT_DATETIME);
	}

	//oExcelFont get_font()
	//{
	//	return oExcelFont(_mgr.get_font(*this));
	//}
	//oCellFormat& set_font(const oExcelFont& font)
	//{
	//	_font_idx = _mgr.get_font_idx(font);
	//	flush();
	//	return *this;
	//}

	System::String ^get_format_string() 
	{
		System::String ^systemstring = gcnew System::String(m_poCellFormat->_mgr.get_format_string(*m_poCellFormat).c_str());
		return systemstring;
	}

	void set_format_string(System::String ^sfmt_str)
	{
		pin_ptr<const wchar_t> wch = PtrToStringChars(sfmt_str);
		wstring fmt_str(wch);
		m_poCellFormat->_mgr.get_format_idx(fmt_str);
		m_poCellFormat->flush();
	}

	int get_color1() 
	{
		return m_poCellFormat->get_color1();
	}
	void set_color1(unsigned color)
	{
		m_poCellFormat->set_color1(color);
		m_poCellFormat->flush();
	}

	unsigned short get_color2() 
	{
		return m_poCellFormat->get_color2();
	}

	void set_color2(unsigned short color)
	{
		m_poCellFormat->set_color2(color);
		m_poCellFormat->flush();
	}

	void set_background(unsigned color1, short color2)
	{
		m_poCellFormat->set_background(color2,color1);
	}

	EXCEL_ALIGNMENT get_alignment() 
	{
		return m_poCellFormat->get_alignment();
	}

	void set_alignment(EXCEL_ALIGNMENT alignment)
	{
		m_poCellFormat->set_alignment(alignment);
		m_poCellFormat->flush();
	}

	bool is_wrapping()
	{
		return m_poCellFormat->is_wrapping();
	}

	void set_wrapping(bool wrap)
	{
		m_poCellFormat->set_wrapping(wrap);
	}

	char get_rotation() 
	{
		return m_poCellFormat->get_rotation();
	}

	void set_rotation(char rotation)
	{
		m_poCellFormat->set_rotation(rotation);
	}

	char get_text_props() 
	{
		return m_poCellFormat->get_text_props();
	}

	void set_text_props(char text_props)
	{
		m_poCellFormat->set_text_props(text_props);
		m_poCellFormat->flush();
	}

	int get_borderlines() 
	{
		return m_poCellFormat->get_borderlines();
	}

	void set_borderlines(int borderlines)
	{
		m_poCellFormat->set_borderlines(borderlines);
	}

	// set borderlines using EXCEL_LS enumeration constants and colour indices
	void set_borderlines(EXCEL_LS left, EXCEL_LS right, EXCEL_LS top, EXCEL_LS bottom,unsigned idxLclr, unsigned idxRclr)
	{
		m_poCellFormat->set_borderlines(left, right, top,  bottom, idxLclr, idxRclr);
	}

	// // set borderlines including the top and bottom colour
	void set_borderlines(EXCEL_LS left, EXCEL_LS right, EXCEL_LS top, EXCEL_LS bottom, 
						unsigned idxLclr, unsigned idxRclr, unsigned idxTclr, unsigned idxBclr,
						EXCEL_LS diag,		// diagonal line style
						COLOR1_PAT pattern	// fill pattern
						)
	{
		m_poCellFormat->set_borderlines(left,right,top,bottom,idxLclr,idxRclr,idxTclr,idxBclr,diag,pattern);
	}



};

public ref class ExcelFont
{
	private:
		struct  ExcelFormat::oExcelFont *m_oExcelFont;

	public:

		System::String			^_name;
		short					_height;			// font height in twips (1/20 of a point)
		short					_weight;			// FW_NORMAL, FW_BOLD, ...
		EXCEL_FONT_OPTIONS		_options;			// see EXCEL_FONT_OPTIONS
		short					_color_index;		// font colour index
		EXCEL_ESCAPEMENT		_escapement_type;	// see EXCEL_ESCAPEMENT
		EXCEL_UNDERLINE_FLAGS	_underline_type;	// see EXCEL_UNDERLINE_FLAGS
		EXCEL_FONT_FAMILY		_font_family;		// see EXCEL_FONT_FAMILY
		char	_character_set;		// ANSI_CHARSET, DEFAULT_CHARSET, SYMBOL_CHARSET, ...

	ExcelFont()
	{
		m_oExcelFont = new ExcelFormat::oExcelFont();

	    _height = m_oExcelFont->_height;
		_options = m_oExcelFont->_options;
		_color_index = m_oExcelFont->_color_index;
		_weight = m_oExcelFont->_weight; // FW_NORMAL
		_escapement_type = m_oExcelFont->_escapement_type;
		_underline_type = m_oExcelFont->_underline_type;
		_font_family = m_oExcelFont->_font_family;
		_character_set =  m_oExcelFont->_character_set;  // ANSI_CHARSET
		_name = gcnew System::String(m_oExcelFont->_name.c_str());
	;}

	void set_height(int height)
	{
	  m_oExcelFont->set_height(height);
	  _height = m_oExcelFont->_height;
	}

	void set_weight(int weight)
	{
	  m_oExcelFont->set_weight(weight);
	  _weight = m_oExcelFont->_weight;
	}

	void set_italic(bool italic)
	{
		m_oExcelFont->set_italic(italic);
	}

	void set_color_index(int color_idx)
	{
		m_oExcelFont->set_color_index(color_idx);
	}

	void set_underline_type(EXCEL_UNDERLINE_FLAGS underline_type)
	{
		m_oExcelFont->set_underline_type(underline_type);
	}

	void set_escapement(EXCEL_ESCAPEMENT escapement_type)
	{
		m_oExcelFont->set_escapement(escapement_type);
	}

	void set_font_name(System::String ^sname)
	{
		pin_ptr<const wchar_t> wch = PtrToStringChars(sname);
		wchar_t name[200];
		wcscpy_s(name, wch);
		m_oExcelFont->set_font_name(name);
		_name = gcnew System::String(m_oExcelFont->_name.c_str());
	}

	//bool matches(const Workbook::Font& font) const
	//{
	//	if (wstringFromSmallString(font.name_) != _name)
	//		return false;

	//	if (font.height_ != _height)
	//		return false;

	//	if (font.weight_ != _weight)
	//		return false;

	//	if (font.options_ != _options)
	//		return false;

	//	if (font.colourIndex_ != _color_index)
	//		return false;

	//	if (font.escapementType_ != _escapement_type)
	//		return false;

	//	if (font.underlineType_ != _underline_type)
	//		return false;

	//	if (font.family_ != _font_family)
	//		return false;

	//	if (font.characterSet_ != _character_set)
	//		return false;

	//	return true;
	//}
};


}

namespace YExcel {

inline void oExcelCell::SetFormat(const ExcelFormat::oCellFormat& fmt)
{
	_xf_idx = fmt.get_xf_idx();
}

inline void oExcelCell::SetFormat(const ExcelFormat::oCellFormat *pfmt)
{
	_xf_idx = pfmt->get_xf_idx();
}

}

#endif	// EXCELFORMAT_H
