/********************************************************************************
  Copyright 2012 Rick Miller and Pulp Free Press - All Rights Reserved 
    The source code contained within this file is intended for educational 
  purposes only. No warranty as to the quality of the code is expressed or 
  implied. 
    Feel free to use this code provided you include the copyright notice in its
  entirety.
**********************************************************************************/ 


using System;
using System.IO;
using System.Text;
using System.Threading;
using System.Collections;
using System.Collections.Generic;


public class DataFileAdapter : LegacyDatafileInterface {

  /**************************************
     * Constants
     ***************************************/

    private const short FILE_IDENTIFIER = 378;
    private const int HEADER_LENGTH = 54;
    private const int RECORDS_START = 54;
    private const int RECORD_LENGTH = 130;
    private const int FIELD_COUNT = 7;

    private const short DELETED_FIELD_LENGTH = 1;
    private const short TITLE_FIELD_LENGTH = 50;
    private const short AUTHOR_FIELD_LENGTH = 50;
    private const short PUB_CODE_FIELD_LENGTH = 4;
    private const short ISBN_FIELD_LENGTH = 13;
    private const short PRICE_FIELD_LENGTH = 8;
    private const short QOH_FIELD_LENGTH = 4;

    private const String DELETED_STRING = "deleted";
    private const String TITLE_STRING = "title";
    private const String AUTHOR_STRING = "author";
    private const String PUB_CODE_STRING = "pub_code";
    private const String ISBN_STRING = "ISBN";
    private const String PRICE_STRING = "price";
    private const String QOH_STRING = "qoh";

    private const int TITLE_FIELD = 0;
    private const int AUTHOR_FIELD = 1;
    private const int PUB_CODE_FIELD = 2;
    private const int ISBN_FIELD = 3;
    private const int PRICE_FIELD = 4;
    private const int QOH_FIELD = 5;

    private const int VALID = 0;
    private const int DELETED = 1;

    /********************************************************
          * Private Instance Fields
          *********************************************************/
    private String _filename = null;
    private BinaryReader _reader = null;
    private BinaryWriter _writer = null;
    private long _record_count = 0;
    private Hashtable _locked_records_map = null;
    private Random _token_maker = null;
    private long _current_record_number = 0;
    private bool _debug = false;

    /*******************************************************
          *  Properties
          * *****************************************************/
    public long RecordCount {
       get { return _record_count; }
     }

    /********************************************************
             *        Instance Methods
            ********************************************************/  
     
    /// <summary>
    /// Constructor
    /// </summary>
    /// <param name="filename"></param>
    /// <exception cref="InvalidDataFileException"></exception>
    public DataFileAdapter(String filename) {
      try {
        _filename = filename;
        if(File.Exists(_filename)){
          _reader = new BinaryReader(File.Open(filename, FileMode.Open));
          if ((_reader.BaseStream.Length >= HEADER_LENGTH) && (_reader.ReadInt16() == FILE_IDENTIFIER)) { // it's a valid data file
             Console.WriteLine(_filename + " is a valid data file...");
             _record_count = ((_reader.BaseStream.Length - HEADER_LENGTH) / RECORD_LENGTH);
             Console.WriteLine("Record count is: " + _record_count);
             InitializeVariables();
             _reader.Close();
            } else if (_reader.BaseStream.Length == 0) { // The file exists but it's empty - make it a data file
                    _reader.Close();
                    WriteHeader(FileMode.Open);
                    InitializeVariables();
                   } else {
                      _reader.BaseStream.Seek(0, SeekOrigin.Begin);
                      if (_reader.ReadInt16() != FILE_IDENTIFIER) {
                        _reader.Close();
                        Console.WriteLine("From DataFileAdapter Constructor(): Invalid data file. Closing file.");
                        throw new InvalidDataFileException("Invalid data file identifier...");
                      }
                   }
        }else {
          CreateNewDataFile(_filename);
        }
      }catch (ArgumentException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
        } 
       catch (EndOfStreamException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("End of stream exception.",e);
        }
       catch (ObjectDisposedException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("BinaryReader not initialized.",e);
        }
       catch (IOException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("General IOException",e);
        }         
       catch (Exception e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("General Exception",e);
        } 
        finally {
          if (_reader != null) {
            _reader.Close();
          }
        }
    } // end constructor


    /// <summary>
    /// Default Constructor
    /// </summary>
    /// <exception cref="InvalidDataFileException"></exception>
    public DataFileAdapter():this("books.dat"){ }


    /// <summary>
    /// Create new file
    /// </summary>
    /// <param name="filename"></param>
    /// <exception cref="NewDataFileException"></exception>
    public void CreateNewDataFile(String filename) {
      try {
        _filename = filename;
        WriteHeader(FileMode.Create);
        InitializeVariables();
      } catch (Exception e) {
          if(_debug) { Console.WriteLine(e); }
          throw new NewDataFileException(e.ToString());
        }
    } // end createNewDataFile method



    /// <summary>
    /// Read the record indicated by the rec_no and return a string array 
    /// were each element contains a field value.
    /// </summary>
    /// <param name="rec_no"></param>
    /// <returns>A populated string array containing record field values</returns>
    /// <exception cref="RecordNotFoundException"></exception>
    public String[] ReadRecord(long rec_no) {
      String[] temp_string = null;
      if ((rec_no < 0) || (rec_no > _record_count)) {
        if(_debug){ Console.WriteLine("From ReadRecord(): Requested record out of range!"); }
         throw new RecordNotFoundException("From ReadRecord(): Requested record out of range");
      } else {
          try {
            _reader = new BinaryReader(File.Open(_filename, FileMode.Open));
            GotoRecordNumber(_reader, rec_no);
            if (_reader.ReadByte() == DELETED) {
              if(_debug){ Console.WriteLine("From ReadRecord(): Record number " + rec_no + " has been deleted!"); }
              throw new RecordNotFoundException("Record " + rec_no + " deleted!");
            } else {
                temp_string = RecordBytesToStringArray(_reader, rec_no);
              }
          } catch (ArgumentException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new RecordNotFoundException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
        } 
       catch (EndOfStreamException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new RecordNotFoundException("End of stream exception.",e);
        }
       catch (ObjectDisposedException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new RecordNotFoundException("BinaryReader not initialized.",e);
        }
       catch (IOException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new RecordNotFoundException("General IOException",e);
        }         
       catch (Exception e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new RecordNotFoundException("General Exception",e);
        } 
            finally {
                if (_reader != null) {
                    _reader.Close();
                }
            }
        } // end else
      return temp_string;
    } // end readRecord()






    /// <summary>
    /// Update a record's fields. The record must be locked with the lockRecord()
    /// method and the lock_token must be valid. The value for field n appears in
    /// element record[n]. The call to updateRecord() MUST be preceeded by a call
    /// to lockRecord() and followed by a call to unlockRecord()
    /// </summary>
    /// <param name="rec_no"></param>
    /// <param name="record"></param>
    /// <param name="lock_token"></param>
    /// <exception cref="RecordNotFoundException"></exception>
    /// <exception cref="SecurityException"></exception>
    public void UpdateRecord(long rec_no, String[] record, long lock_token) {
      if (lock_token != ((long)_locked_records_map[rec_no])) {
        if(_debug){ Console.WriteLine("From UpdateRecord(): Invalid  update record lock token."); }
        throw new SecurityException("From UpdateRecord(): Invalid update record lock token.");
      } else {
          try {
            _writer = new BinaryWriter(File.Open(_filename, FileMode.Open));
            GotoRecordNumber(_writer, rec_no); //i.e., goto indicated record
            _writer.Write((byte)0);
            _writer.Write(StringToPaddedByteField(record[TITLE_FIELD], TITLE_FIELD_LENGTH));
            _writer.Write(StringToPaddedByteField(record[AUTHOR_FIELD], AUTHOR_FIELD_LENGTH));
            _writer.Write(Int16.Parse(record[PUB_CODE_FIELD]));
            _writer.Write(StringToPaddedByteField(record[ISBN_FIELD], ISBN_FIELD_LENGTH));
            _writer.Write(StringToPaddedByteField(record[PRICE_FIELD], PRICE_FIELD_LENGTH));
            _writer.Write(Int16.Parse(record[QOH_FIELD]));
            _current_record_number = rec_no;
          } catch (ArgumentException e) {
             if(_debug){ Console.WriteLine(e.ToString()); }
             throw new RecordNotFoundException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
            } 
           catch (EndOfStreamException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("End of stream exception.",e);
           }
           catch (ObjectDisposedException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("BinaryReader not initialized.",e);
            }
           catch (IOException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("General IOException",e);
           }         
           catch (Exception e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("General Exception",e);
           } 
            finally {
              if (_writer != null) {
                _writer.Close();
              }
            }
        }// end else
    }// end updateRecord()


    /// <summary>
    /// Marks a record for deletion by setting the deleted field to 1. The lock_token
    /// must be valid otherwise a SecurityException is thrown.
    /// </summary>
    /// <param name="rec_no"></param>
    /// <param name="lock_token"></param>
    /// <exception cref="RecordNotFoundException"></exception>
    /// <exception cref="SecurityException"></exception>
    public void DeleteRecord(long rec_no, long lock_token) {
      if (lock_token != (long)_locked_records_map[rec_no]) {
        Console.WriteLine("From DeleteRecord(): Invalid delete record lock token.");
        throw new SecurityException("From DeleteRecord(): Invalid delete record lock token.");
      } else {
          try {
            _writer = new BinaryWriter(File.Open(_filename, FileMode.Open));
            GotoRecordNumber(_writer, rec_no); // goto record indicated
            _writer.Write((byte)1);  // mark for deletion
          } catch (ArgumentException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
           } 
           catch (EndOfStreamException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("End of stream exception.",e);
           }
           catch (ObjectDisposedException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("BinaryReader not initialized.",e);
           }
           catch (IOException e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("General IOException",e);
           }         
          catch (Exception e) {
            if(_debug){ Console.WriteLine(e.ToString()); }
            throw new RecordNotFoundException("General Exception",e);
          } 
            finally {
              if (_writer != null) {
                 _writer.Close();
              }
            }
        }// end else
    }// end deleteRecord() 





    /// <summary>
    /// Creates a new datafile record and returns the record number.
    /// </summary>
    /// <param name="record"></param>
    /// <returns> The record number of the newly created record</returns>
    /// <exception cref="FailedRecordCreationException"></exception>
    public long CreateRecord(String[] record) {
      try {
        _writer = new BinaryWriter(File.Open(_filename, FileMode.Open));
        GotoRecordNumber(_writer, _record_count); //i.e., goto end of file
        _writer.Write((byte)0);
        _writer.Write(StringToPaddedByteField(record[TITLE_FIELD], TITLE_FIELD_LENGTH));
        _writer.Write(StringToPaddedByteField(record[AUTHOR_FIELD], AUTHOR_FIELD_LENGTH));
        _writer.Write(Int16.Parse(record[PUB_CODE_FIELD]));
        _writer.Write(StringToPaddedByteField(record[ISBN_FIELD], ISBN_FIELD_LENGTH));
        _writer.Write(StringToPaddedByteField(record[PRICE_FIELD], PRICE_FIELD_LENGTH));
        _writer.Write(Int16.Parse(record[QOH_FIELD]));
        _current_record_number = ++_record_count;
      } catch (ArgumentException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new FailedRecordCreationException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
        } 
       catch (EndOfStreamException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new FailedRecordCreationException("End of stream exception.",e);
        }
       catch (ObjectDisposedException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new FailedRecordCreationException("BinaryReader not initialized.",e);
        }
       catch (IOException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new FailedRecordCreationException("General IOException",e);
        }         
       catch (Exception e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new FailedRecordCreationException("General Exception",e);
        } 
        finally {
          if (_writer != null) {
            _writer.Close();
          }
        }
      return _current_record_number;
    } // end CreateRecord() 

    /// <summary>
    /// Locks a record for updates and deletes  - returns an integer
    /// representing a lock token.
    /// </summary>
    /// <param name="rec_no"></param>
    /// <returns></returns>
    /// <exception cref="RecordNotFoundException"></exception>
    public long LockRecord(long rec_no) {
      long lock_token = 0;
      if ((rec_no < 0) || (rec_no > _record_count)) {
        if(_debug){ Console.WriteLine("From LockRecord(): Record cannot be locked. Not in valid range."); }
        throw new RecordNotFoundException("From LockRecord(): Record cannot be locked. Not in valid range.");
      } else {
          lock (_locked_records_map) {
          while (_locked_records_map.ContainsKey(rec_no)) {
            try {
              Monitor.Wait(_locked_records_map);
            } catch (Exception) { }
          }
          lock_token = (long)_token_maker.Next();
          _locked_records_map.Add(rec_no, lock_token);
          } // end lock
        } // end else
      return lock_token;
    } // end LockRecord()


    /// <summary>
    /// Unlocks a previously locked record. The lock_token must be valid or a
    /// SecurityException is thrown.
    /// </summary>
    /// <param name="rec_no"></param>
    /// <param name="lock_token"></param>
    /// <exception cref="SecurityException"></exception>
    public void UnlockRecord(long rec_no, long lock_token) {
      lock (_locked_records_map) {
        if (_locked_records_map.Contains(rec_no)) {
          if (lock_token == ((long)_locked_records_map[rec_no])) {
             _locked_records_map.Remove(rec_no);
             Monitor.Pulse(_locked_records_map);
          } else {
              if(_debug){ Console.WriteLine("From UnlockRecord(): Invalid lock token."); }
              throw new SecurityException("From UnlockRecord(): Invalid lock token");
            }
          } else {
              if(_debug){ Console.WriteLine("From UnlockRecord(): Invalid record number."); }
              throw new SecurityException("From UnlockRecord(): Invalid record number.");
            }
        }
    }// end UnlockRecord()


    /// <summary>
    /// Searches the records in the datafile for records that match the String
    /// values of search_criteria. search_criteria[n] contains the search value
    /// applied against field n. Data files can be searched for Title & Author.
    /// </summary>
    /// <param name="search_criteria"></param>
    /// <returns>An array of long values each indicating a record number match</returns>
    public long[] SearchRecords(String[] search_criteria) {
      List<long> hit_list = new List<long>();
      for (long i = 0; i < _record_count; i++) {
        try {
          if (ThereIsAMatch(search_criteria, ReadRecord(i))) {
             hit_list.Add(i);
          }
        } catch (RecordNotFoundException) { } // ignore deleted records
      } // end for
      long[] hits = new long[hit_list.Count];
      for (int i = 0; i < hits.Length; i++) {
        hits[i] = hit_list[i];
      }
      return hits;
    } // end SearchRecords()


    /// <summary>
    /// ThereIsAMatch() is a utility method that actually performs
    /// the record search. Implements an implied OR/AND search by detecting 
    /// the first character of the Title criteria element.
    /// </summary>
    /// <param name="search_criteria"></param>
    /// <param name="record"></param>
    /// <returns>A boolean value indicating true if there is a match or false otherwise.</returns>
    private bool ThereIsAMatch(String[] search_criteria, String[] record) {
      bool match_result = false;
      int TITLE = 0;
      int AUTHOR = 1;
      for (int i = 0; i < search_criteria.Length; i++) {
        if ((search_criteria[i].Length == 0) || (record[i + 1].StartsWith(search_criteria[i]))) {
           match_result = true;
           break;
        } //end if
      } //end for

      if (((search_criteria[TITLE].Length > 1) && (search_criteria[AUTHOR].Length >= 1)) &&
                                                  (search_criteria[TITLE][0] == '&')) {
         if (record[TITLE + 1].StartsWith(search_criteria[TITLE].Substring(1, search_criteria[TITLE].Length).Trim()) &&
                                                             record[AUTHOR + 1].StartsWith(search_criteria[AUTHOR])) {
                match_result = true;
         } else {
              match_result = false;
           }
      } // end  outer if
      return match_result;
    } // end thereIsAMatch()


    /// <summary>
    /// GotoRecordNumber - utility function that handles the messy
    /// details of seeking a particular record.
    /// </summary>
    /// <param name="record_number"></param>
    /// <exception cref="RecordNotFoundException"></exception>
    private void GotoRecordNumber(BinaryReader reader, long record_number) {
      if ((record_number < 0) || (record_number > _record_count)) {
        throw new RecordNotFoundException();
      } else {
          try {
            reader.BaseStream.Seek(RECORDS_START + (record_number * RECORD_LENGTH), SeekOrigin.Begin);
          } catch (EndOfStreamException e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("End of stream exception.",e);
            }
            catch (ObjectDisposedException e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("BinaryReader not initialized.",e);
            }
            catch (IOException e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("General IOException",e);
            }         
            catch (Exception e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("General Exception",e);
            } 
        }// end else
    } // end GotoRecordNumber()


    /// <summary>
    /// GotoRecordNumber - overloaded utility function that handles the messy
    /// details of seeking a particular record.
    /// </summary>
    /// <param name="record_number"></param>
    /// <exception cref="RecordNotFoundException"></exception>
    private void GotoRecordNumber(BinaryWriter writer, long record_number) {
      if ((record_number < 0) || (record_number > _record_count)) {
        throw new RecordNotFoundException();
      } else {
          try {
            writer.BaseStream.Seek(RECORDS_START + (record_number * RECORD_LENGTH), SeekOrigin.Begin);
          } catch (EndOfStreamException e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("End of stream exception.",e);
            }
            catch (ObjectDisposedException e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("BinaryReader not initialized.",e);
            }
            catch (IOException e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("General IOException",e);
            }         
            catch (Exception e) {
              if(_debug){ Console.WriteLine(e.ToString()); }
              throw new RecordNotFoundException("General Exception",e);
            } 
        }// end else
    } // end GotoRecordNumber()


    /// <summary>
    /// stringToPaddedByteField - pads the field to maintain fixed
    /// field length.
    /// </summary>
    /// <param name="s"></param>
    /// <param name="field_length"></param>
    /// <returns>A populated byte array containing the string value padded with spaces</returns>
    protected byte[] StringToPaddedByteField(String s, int field_length) {
      byte[] byte_field = new byte[field_length];
      if (s.Length <= field_length) {
         for (int i = 0; i < s.Length; i++) {
           byte_field[i] = (byte)s[i];
         }
         for (int i = s.Length; i < field_length; i++) {
           byte_field[i] = (byte)' '; //pad the field
         }
      } else {
          for (int i = 0; i < field_length; i++) {
            byte_field[i] = (byte)s[i];
          }
        }
      return byte_field;
    } // end StringToPaddedByteField()


    /// <summary>
    /// RecordBytesToStringArray - reads an array of bytes from a data file
    /// and converts them to an array of Strings. The first element of the
    /// returned array is the record number. The length of the byte array
    /// argument is RECORD_LENGTH -1.
    /// </summary>
    /// <param name="record_number"></param>
    /// <returns></returns>
    private String[] RecordBytesToStringArray(BinaryReader reader, long record_number) {
      String[] string_array = new String[FIELD_COUNT];
      char[] title = new char[TITLE_FIELD_LENGTH];
      char[] author = new char[AUTHOR_FIELD_LENGTH];
      char[] isbn = new char[ISBN_FIELD_LENGTH];
      char[] price = new char[PRICE_FIELD_LENGTH];
      try {
        string_array[0] = record_number.ToString();
        reader.Read(title, 0, title.Length);
        string_array[TITLE_FIELD + 1] = new String(title).Trim();
        reader.Read(author, 0, author.Length);
        string_array[AUTHOR_FIELD + 1] = new String(author).Trim();
        string_array[PUB_CODE_FIELD + 1] = (reader.ReadInt16()).ToString();
        reader.Read(isbn, 0, isbn.Length);
        string_array[ISBN_FIELD + 1] = new String(isbn);
        reader.Read(price, 0, price.Length);
        string_array[PRICE_FIELD + 1] = new String(price).Trim();
        string_array[QOH_FIELD + 1] = (reader.ReadInt16()).ToString();
      } catch (IOException e) {
          Console.WriteLine(e.ToString());
        }
      return string_array;
    } // end recordBytesToStringArray()


    /// <summary>
    /// Writes the header information into a data file
    /// </summary>
    /// <exception cref="InvalidDataFileException"></exception>
    private void WriteHeader(FileMode file_mode) {
      try {
        if (_writer != null) {
          _writer.Close();
        }
        _writer = new BinaryWriter(File.Open(_filename, file_mode));
        _writer.Seek(0, SeekOrigin.Begin);
        _writer.Write(FILE_IDENTIFIER);
        _writer.Write(DELETED_STRING.ToCharArray());
        _writer.Write(DELETED_FIELD_LENGTH);
        _writer.Write(TITLE_STRING.ToCharArray());
        _writer.Write(TITLE_FIELD_LENGTH);
        _writer.Write(AUTHOR_STRING.ToCharArray());
        _writer.Write(AUTHOR_FIELD_LENGTH);
        _writer.Write(PUB_CODE_STRING.ToCharArray());
        _writer.Write(PUB_CODE_FIELD_LENGTH);
        _writer.Write(ISBN_STRING.ToCharArray());
        _writer.Write(ISBN_FIELD_LENGTH);
        _writer.Write(PRICE_STRING.ToCharArray());
        _writer.Write(PRICE_FIELD_LENGTH);
        _writer.Write(QOH_STRING.ToCharArray());
        _writer.Write(QOH_FIELD_LENGTH);
        _writer.Flush();
      }catch (ArgumentException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
        } 
       catch (EndOfStreamException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("End of stream exception.",e);
        }
       catch (ObjectDisposedException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("BinaryReader not initialized.",e);
        }
       catch (IOException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("General IOException",e);
        }         
       catch (Exception e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("General Exception",e);
        } 
        finally {
          if (_writer != null) {
            _writer.Close();
          }
        }
    } // end WriteHeader()


    /// <summary>
    /// readHeader - reads the header bytes and converts them to
    /// a string
    /// </summary>
    /// <returns> A String containing the file header information</returns>
    /// <exception cref="InvalidDataFileException"></exception>
    public String ReadHeader() {
      StringBuilder sb = new StringBuilder();
      char[] deleted = new char[DELETED_STRING.Length];
      char[] title = new char[TITLE_STRING.Length];
      char[] author = new char[AUTHOR_STRING.Length];
      char[] pub_code = new char[PUB_CODE_STRING.Length];
      char[] isbn = new char[ISBN_STRING.Length];
      char[] price = new char[PRICE_STRING.Length];
      char[] qoh = new char[QOH_STRING.Length];
      try {
        _reader = new BinaryReader(File.Open(_filename, FileMode.Open));
        _reader.BaseStream.Seek(0, SeekOrigin.Begin);
        sb.Append(_reader.ReadInt16() + " ");
        _reader.Read(deleted, 0, deleted.Length);
        sb.Append(new String(deleted) + " ");
        sb.Append(_reader.ReadInt16() + " ");
        _reader.Read(title, 0, title.Length);
        sb.Append(new String(title) + " ");
        sb.Append((_reader.ReadInt16()) + " ");
        _reader.Read(author, 0, author.Length);
        sb.Append(new String(author) + " ");
        sb.Append((_reader.ReadInt16()) + " ");
        _reader.Read(pub_code, 0, pub_code.Length);
        sb.Append(new String(pub_code) + " ");
        sb.Append((_reader.ReadInt16()) + " ");
        _reader.Read(isbn, 0, isbn.Length);
        sb.Append(new String(isbn) + " ");
        sb.Append((_reader.ReadInt16()) + " ");
        _reader.Read(price, 0, price.Length);
        sb.Append(new String(price) + " ");
        sb.Append((_reader.ReadInt16()) + " ");
        _reader.Read(qoh, 0, qoh.Length);
        sb.Append(new String(qoh) + " ");
        sb.Append((_reader.ReadInt16()) + " ");
      } catch (ArgumentException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("Invalid argument to BinaryReader constructor or FileSteam.Seek method.",e);
        } 
       catch (EndOfStreamException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("End of stream exception.",e);
        }
       catch (ObjectDisposedException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("BinaryReader not initialized.",e);
        }
       catch (IOException e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("General IOException",e);
        }         
       catch (Exception e) {
          if(_debug){ Console.WriteLine(e.ToString()); }
          throw new InvalidDataFileException("General Exception",e);
        } 
        finally {
          if (_reader != null) {
            _reader.Close();
          }
        }
      return sb.ToString();
    } // end ReadHeader()

    
    /// <summary>
    /// Utility method used to initialize several important instance fields
    /// </summary>
    private void InitializeVariables() {
      _current_record_number = 0;
      _locked_records_map = new Hashtable();
      _token_maker = new Random();
    }

} // end DataFileAdapter class definition