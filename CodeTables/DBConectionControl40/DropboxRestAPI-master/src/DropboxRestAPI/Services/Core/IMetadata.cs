/*
 * The MIT License (MIT)
 * 
 * Copyright (c) 2014 Itay Sagui
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */


using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using DropboxRestAPI.Models.Core;

namespace DropboxRestAPI.Services.Core
{
    public interface IMetadata
    {
        /// <summary>
        /// Downloads a file.
        /// </summary>
        /// <param name="path">The path to the file you want to retrieve.</param>
        /// <param name="targetStream">Stream where the file content will be downloaded.</param>
        /// <param name="rev">The revision of the file to retrieve. This defaults to the most recent revision.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The specified file's contents at the requested revision.</returns>
        Task<MetaData> FilesAsync(string path, Stream targetStream, string rev = null, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Uploads a file using PUT semantics.
        /// </summary>
        /// <param name="content">The file contents to be uploaded.</param>
        /// <param name="path">The full path to the file you want to write to. This parameter should not point to a folder.</param>
        /// <param name="locale">The metadata returned on successful upload will have its size field translated based on the given locale.</param>
        /// <param name="overwrite">
        /// This value, either true (default) or false, determines whether an existing file will be overwritten by this upload. If
        /// true, any existing file will be overwritten. If false, the other parameters determine whether a conflict occurs and how
        /// that conflict is resolved.
        /// </param>
        /// <param name="parent_rev">
        /// If present, this parameter specifies the revision of the file you're editing. If parent_rev matches the latest version
        /// of the file on the user's Dropbox, that file will be replaced. Otherwise, a conflict will occur. (See below.) If you
        /// specify a parent_rev and that revision doesn't exist, the file won't save (error 400). You can get the most recent rev
        /// by performing a call to /metadata.
        /// </param>
        /// <param name="autorename">
        /// This value, either true (default) or false, determines what happens when there is a conflict. If true, the file being
        /// uploaded will be automatically renamed to avoid the conflict. (For example, test.txt might be automatically renamed to
        /// test (1).txt.) The new name can be obtained from the returned metadata. If false, the call will fail with a 409 (Conflict)
        /// response code.
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The metadata for the uploaded file. </returns>
        Task<MetaData> FilesPutAsync(Stream content, string path, string locale = null, bool overwrite = true, string parent_rev = null, bool autorename = true, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Retrieves file and folder metadata.
        /// <remarks>https://www.dropbox.com/developers/core/docs#metadata</remarks>
        /// </summary>
        /// <param name="path">The path to the file or folder.</param>
        /// <param name="file_limit">
        /// Default is 10,000 (max is 25,000). When listing a folder, the service won't report listings containing more than the
        /// specified amount of files and will instead respond with a 406 (Not Acceptable) status response.
        /// </param>
        /// <param name="hash">
        /// Each call to /metadata on a folder will return a hash field, generated by hashing all of the  metadata contained in that
        /// response. On later calls to /metadata, you should provide that value via this parameter so that if nothing has changed,
        /// the response will be a 304 (Not Modified) status code instead of the full, potentially very  large, folder listing. This
        /// parameter is ignored if the specified path is associated with a file or if list=false.
        /// </param>
        /// <param name="list">
        /// The strings true and false are valid values. true is the default. If true, the folder's metadata will include a contents
        /// field with a list of metadata entries for the contents of the folder. If false, the contents field will be omitted.
        /// </param>
        /// <param name="include_deleted">
        /// Only applicable when list is set. If this parameter is set to true, then contents will include the metadata of deleted
        /// children. Note that the target of the metadata call is always returned even when it has been deleted (with is_deleted
        /// set to true) regardless of this flag.
        /// </param>
        /// <param name="rev">If you include a particular revision number, then only the metadata for that revision will be returned.</param>
        /// <param name="locale">The metadata returned will have its size field translated based on the given locale.</param>
        /// <param name="include_media_info">If true, each file will include a photo_info dictionary for photos and a video_info
        /// dictionary for videos with additional media info. If the data isn't available yet, the string pending will be returned
        /// instead of a dictionary.</param>
        /// <param name="include_membership">
        /// If true, metadata for a shared folder will include a list of the members of the shared folder.
        /// <remarks>Heads up: The include_membership parameter is part of the Shared Folder extensions in production beta.</remarks>
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// The metadata for the file or folder at the given &lt;path&gt;. If &lt;path&gt; represents a folder and the list parameter is
        /// true, the metadata will also include a listing of metadata for the folder's contents.
        /// </returns>
        Task<MetaData> MetadataAsync(string path, int file_limit = 10000, string hash = null, bool list = true, bool include_deleted = false, string rev = null, string locale = null, bool include_media_info = false, bool include_membership = false, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// A way of letting you keep up with changes to files and folders in a user's Dropbox. You can periodically call /delta to
        /// get a list of "delta entries", which are instructions on how to update your local state to match the server's state.
        /// </summary>
        /// <param name="cursor">
        /// A string that is used to keep track of your current state. On the next call pass in this value to return delta entries
        /// that have been recorded since the cursor was returned.
        /// </param>
        /// <param name="locale">The metadata returned will have its size field translated based on the given locale.</param>
        /// <param name="path_prefix">
        /// If present, this parameter filters the response to only include entries at or under the specified path. For example,
        /// a path_prefix of "/Photos/Vacation" will return entries for the path "/Photos/Vacation" and any files and folders under
        /// that path. If you use the path_prefix parameter, you must continue to pass the correct prefix on subsequent calls using
        /// the returned cursor. You can switch the path_prefix on any existing cursor to a descendant of the existing path_prefix
        /// on subsequent calls to /delta. For example if your cursor has no path_prefix, you can switch to any path_prefix. If your
        /// cursor has a path_prefix of "/Photos", you can switch it to "/Photos/Vacaction".
        /// </param>
        /// <param name="include_media_info">
        /// If true, each file will include a photo_info dictionary for photos and a video_info dictionary for videos with additional
        /// media info. When include_media_info is specified, files will only appear in delta responses when the media info is ready.
        /// If you use the include_media_info parameter, you must continue to pass the same value on subsequent calls using the
        /// returned cursor.
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>List of changes to files and folders in a user's Dropbox.</returns>
        Task<Entries> DeltaAsync(string cursor = null, string locale = null, string path_prefix = null, bool include_media_info = false, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// A way to quickly get a cursor for the server's state, for use with /delta. Unlike /delta, /delta/latest_cursor does not
        /// return any entries, so your app will not know about any existing files or folders in the Dropbox account. For example,
        /// if your app processes future delta entries and sees that a folder was deleted, your app won't know what files were in
        /// that folder. Use this endpoint if your app only needs to know about new files and modifications and doesn't need to know
        /// about files that already exist in Dropbox.
        /// </summary>
        /// <param name="path_prefix">If present, the returned cursor will be encoded with a path_prefix for the specified path for use with /delta.</param>
        /// <param name="include_media_info">If true, the returned cursor will be encoded with include_media_info set to true for use with /delta.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The latest server state, as would be returned by /delta when has_more is false.</returns>
        Task<DeltaCursor> DeltaLatestCursorAsync(string path_prefix = null, bool include_media_info = false, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// A long-poll endpoint to wait for changes on an account. In conjunction with /delta, this call gives you a low-latency way
        /// to monitor an account for file changes.
        /// </summary>
        /// <param name="cursor">
        /// A delta cursor as returned from a call to /delta. Note that a cursor returned from a call to /delta with
        /// include_media_info=true is incompatible with /longpoll_delta and an error will be returned.
        /// </param>
        /// <param name="timeout">
        /// An optional integer indicating a timeout, in seconds. The default value is 30 seconds, which is also the minimum allowed
        /// value. The maximum is 480 seconds. The request will block for at most this length of time, plus up to 90 seconds of random
        /// jitter added to avoid the thundering herd problem. Care should be taken when using this parameter, as some network
        /// infrastructure does not support long timeouts.
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// The connection will block until there are changes available or a timeout occurs. The value of the changes field indicates
        /// whether new changes are available. If this value is true, you should call /delta to retrieve the changes. If this value
        /// is false, it means the call to /longpoll_delta timed out.
        /// </returns>
        Task<LongPollDelta> LongPollDeltaAsync(string cursor = null, int timeout = 30, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Obtains metadata for the previous revisions of a file. 
        /// Only revisions up to thirty days old are available (or more if the Dropbox user has Packrat). You can use the revision
        /// number in conjunction with the /restore call to revert the file to its previous state.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="rev_limit">Default is 10. Max is 1,000. Up to this number of recent revisions will be returned.</param>
        /// <param name="locale">The metadata returned will have its size field translated based on the given locale.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>A list of revisions.</returns>
        Task<IEnumerable<MetaData>> RevisionsAsync(string path, int rev_limit = 10, string locale = null, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Restores a file path to a previous revision.
        /// Unlike downloading a file at a given revision and then re-uploading it, this call is atomic. It also saves a bunch of bandwidth.
        /// </summary>
        /// <param name="path">The path to the file.</param>
        /// <param name="rev">The revision of the file to restore. </param>
        /// <param name="locale">The metadata returned will have its size field translated based on the given locale.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The metadata of the restored file.</returns>
        Task<MetaData> RestoreAsync(string path, string rev = null, string locale = null, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns metadata for all files and folders whose filename contains the given search string as a substring.
        /// Searches are limited to the folder path and its sub-folder hierarchy provided in the call.
        /// </summary>
        /// <param name="path">The path to the folder you want to search from.</param>
        /// <param name="query">
        /// The search string. This string is split (on spaces) into individual words. Files and folders will be returned if they
        /// contain all words in the search string.
        /// </param>
        /// <param name="file_limit">The maximum and default value is 1,000. No more than file_limit search results will be returned.</param>
        /// <param name="include_deleted">
        /// If this parameter is set to true, then files and folders that have been deleted will also be included in the search.
        /// </param>
        /// <param name="locale">The metadata returned will have its size field translated based on the given locale.</param>
        /// <param name="include_membership">If true, metadata for a shared folder will include a list of the members of the shared folder.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>List of metadata entries for any matching files and folders. </returns>
        Task<IEnumerable<MetaData>> SearchAsync(string path, string query, int file_limit = 1000, bool include_deleted = false, string locale = null, bool include_membership = false, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates and returns a shared link to a file or folder.
        /// </summary>
        /// <param name="path">The path to the file or folder you want to link to.</param>
        /// <param name="locale">Use to specify language settings for user error messages and other language specific text.</param>
        /// <param name="short_url">
        /// When true (default), the URL returned will be shortened using the Dropbox URL shortener. If false, the URL will link
        /// directly to the file's preview page.
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The shared link as well as information about the link's visibility and expiration</returns>
        Task<SharedLink> SharesAsync(string path, string locale = null, bool short_url = true, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns a link directly to a file.
        /// Similar to /shares. The difference is that this bypasses the Dropbox webserver, used to provide a preview of the file, so
        /// that you can effectively stream the contents of your media. This URL should not be used to display content directly in the
        /// browser.
        /// </summary>
        /// <param name="path">The path to the media file you want a direct link to.</param>
        /// <param name="locale">Use to specify language settings for user error messages and other language specific text.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns> url that serves the media directly. Also returns the link's expiration date.</returns>
        Task<MediaLink> MediaAsync(string path, string locale = null, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Creates and returns a copy_ref to a file. This reference string can be used to copy that file to another user's Dropbox by
        /// passing it in as the from_copy_ref parameter on /fileops/copy.
        /// </summary>
        /// <param name="path">The path to the file you want a copy_ref to refer to.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// A copy_ref to the specified file. For compatibility reasons, it returns the link's expiration date. All links are currently
        /// set to expire far enough in the future so that expiration is effectively not an issue.
        /// </returns>
        Task<CopyRef> CopyRefAsync(string path, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a thumbnail for an image. 
        /// </summary>
        /// <param name="path">The path to the image file you want to thumbnail.</param>
        /// <param name="format">
        /// jpeg (default) or png. For images that are photos, jpeg should be preferred, while png is better for screenshots and
        /// digital art.
        /// </param>
        /// <param name="size">
        /// One of the following values (default: s):
        /// value  | dimensions (px)
        ///  xs    |  32x32 
        ///  s     |  64x64 
        ///  m     |  128x128 
        ///  l     |  640x480 
        ///  xl    |  1024x768 
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns></returns>
        /// <remarks>
        /// This method currently supports files with the following file extensions: "jpg", "jpeg", "png", "tiff", "tif", "gif", and "bmp".
        /// Photos that are larger than 20MB in size won't be converted to a thumbnail.
        /// </remarks>
        Task<Stream> ThumbnailsAsync(string path, string format = "jpeg", string size = "s", string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Gets a preview for a file. 
        /// </summary>
        /// <param name="path">The absolute path to the file you want to preview.</param>
        /// <param name="rev">The revision of the file to retrieve. This defaults to the most recent revision.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns></returns>
        /// <remarks>
        /// Previews are only generated for the files with the following extensions: .doc, .docx, .docm, .ppt, .pps, .ppsx, .ppsm, .pptx, 
        /// .pptm, .xls, .xlsx, .xlsm, .rtf, .pdf
        /// </remarks>
        Task<Preview> PreviewsAsync(string path, string rev = null, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Uploads large files to Dropbox in multiple chunks. Also has the ability to resume if the upload is interrupted. This
        /// allows for uploads larger than the /files_put maximum of 150 MB.
        /// Typical usage:
        ///  1. Send a PUT request to /chunked_upload with the first chunk of the file without setting upload_id, and receive an
        ///     upload_id in return.
        ///  2. Repeatedly PUT subsequent chunks using the upload_id to identify the upload in progress and an offset representing
        ///     the number of bytes transferred so far.
        ///  3. After each chunk has been uploaded, the server returns a new offset representing the total amount transferred.
        ///  4. After the last chunk, POST to /commit_chunked_upload to complete the upload.
        /// Chunks can be any size up to 150 MB. A typical chunk is 4 MB. Using large chunks will mean fewer calls to /chunked_upload
        /// and faster overall throughput. However, whenever a transfer is interrupted, you will have to resume at the beginning of
        /// the last chunk, so it is often safer to use smaller chunks.
        /// If the offset you submit does not match the expected offset on the server, the server will ignore the request and respond
        /// with a 400 error that includes the current offset. To resume upload, seek to the correct offset (in bytes) within the file
        /// and then resume uploading from that point.
        /// A chunked upload can take a maximum of 24 hours before expiring.
        /// </summary>
        /// <param name="content">
        ///     A chunk of data from the file being uploaded. If resuming, the chunk should begin at the number of bytes into the file
        ///     that equals the offset.
        /// </param>
        /// <param name="count">Number of bytes in the content buffer to send as the chunk</param>
        /// <param name="uploadId">
        ///     The unique ID of the in-progress upload on the server. If left blank, the server will create a
        ///     new upload session.
        /// </param>
        /// <param name="offset">
        ///     The byte offset of this chunk, relative to the beginning of the full file. The server will verify that this matches the
        ///     offset it expects. If it does not, the server will return an error with the expected offset.
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>Details of the upload chunk</returns>
        Task<ChunkedUpload> ChunkedUploadAsync(byte[] content, int count, string uploadId = null, long? offset = null, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Completes an upload initiated by the /chunked_upload method. Saves a file uploaded via /chunked_upload to a user's Dropbox.
        /// /commit_chunked_upload is similar to /files_put. The main difference is that while /files_put takes the file contents in
        /// the request body, /commit_chunked_upload takes a parameter upload_id, which is obtained when the file contents are uploaded
        /// via /chunked_upload.
        /// </summary>
        /// <param name="path">The full path to the file you want to write to. This parameter should not point to a folder.</param>
        /// <param name="uploadId">Used to identify the chunked upload session you'd like to commit.</param>
        /// <param name="locale">The metadata returned on successful upload will have its size field translated based on the given locale.</param>
        /// <param name="overwrite">
        /// This value, either true (default) or false, determines whether an existing file will be overwritten by this upload. If
        /// true, any existing file will be overwritten. If false, the other parameters determine whether a conflict occurs and how
        /// that conflict is resolved.
        /// </param>
        /// <param name="autorename">
        /// This value, either true (default) or false, determines what happens when there is a conflict. If true, the file being
        /// uploaded will be automatically renamed to avoid the conflict. (For example, test.txt might be automatically renamed to
        /// test (1).txt.) The new name can be obtained from the returned metadata. If false, the call will fail with a 409 (Conflict)
        /// response code.
        /// </param>
        /// <param name="parent_rev">
        /// If present, this parameter specifies the revision of the file you're editing. If parent_rev matches the latest version of
        /// the file on the user's Dropbox, that file will be replaced. Otherwise, a conflict will occur. (See below.) If you specify
        /// a parent_rev and that revision doesn't exist, the file won't save (error 400). You can get the most recent rev by performing
        /// a call to /metadata.
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The metadata for the uploaded file.</returns>
        Task<MetaData> CommitChunkedUploadAsync(string path, string uploadId, string locale = null, bool overwrite = true, string parent_rev = null, bool autorename = true, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns metadata about a specific shared folder.
        /// </summary>
        /// <param name="shared_folder_id">The ID of a specific shared folder.</param>
        /// <param name="show_unmounted">
        /// Required if shared_folder_id is specified. If true, include a list of members and a list of
        /// groups for the shared folder.
        /// </param>
        /// <param name="include_membership">
        /// This value, either true or false(default), determines whether the returned list of shared
        /// folders will include shared folders that the user has left (but may still rejoin).
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// The metadata for a specific shared folder if the id parameter is specified.
        /// </returns>
        /// <remarks>
        /// Note that same_team is only present if the linked account is a member of a Dropbox for Business team, and member_id is only
        /// present when this endpoint is called by a Dropbox for Business app and the user is on that team.
        /// 
        /// The path is None for shared folders that the user has left.
        /// 
        /// The membership field only contains users who have joined the shared folder and does not include users who have been invited
        /// but have not accepted.When the active field is false, it means that a user has left a shared folder(but may still rejoin).
        /// </remarks>
        Task<SharedFolder> SharedFolderAsync(string shared_folder_id = null, bool? include_membership = true, bool show_unmounted = false, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Returns a list of all shared folders the authenticated user has access to.
        /// </summary>
        /// <param name="show_unmounted">
        /// Required if shared_folder_id is specified. If true, include a list of members and a list of
        /// groups for the shared folder.
        /// </param>
        /// <param name="include_membership">
        /// This value, either true or false(default), determines whether the returned list of shared
        /// folders will include shared folders that the user has left (but may still rejoin).
        /// </param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// A list of shared folders metadata objects.
        /// </returns>
        /// <remarks>
        /// Note that same_team is only present if the linked account is a member of a Dropbox for Business team, and member_id is only
        /// present when this endpoint is called by a Dropbox for Business app and the user is on that team.
        /// 
        /// The path is None for shared folders that the user has left.
        /// 
        /// The membership field only contains users who have joined the shared folder and does not include users who have been invited
        /// but have not accepted.When the active field is false, it means that a user has left a shared folder(but may still rejoin).
        /// </remarks>
        Task<IEnumerable<SharedFolder>> SharedFoldersAsync(bool? include_membership = true, bool show_unmounted = false, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));


        /// <summary>
        /// Save a file from the speficied URL into Dropbox.  If the given paths already exists, the file will be be renamed to avoid the conflict (e.g. myfile (1).txt).
        /// </summary>
        /// <param name="path">The path in Dropbox where the file will be saved</param>
        /// <param name="url">The URL to be fetched</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// A dictionary with a status and job. The status is as defined in the save_url_job documentation.  The job field gives a job ID that can be used with the save_url_job endpoint to check the job's status.
        /// </returns>
        Task<SaveUrl> SaveUrlAsync(string path, string url, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));

        /// <summary>
        /// Check the status of a save URL job.
        /// </summary>
        /// <param name="jobId">A job ID returned from /save_url.</param>
        /// <param name="asTeamMember">Specify the member_id of the user that the app wants to act on.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>
        /// A dictionary with a status field with one of the following values: PENDING � The job has not yet started. DOWNLOADING � The job has started but hasn't yet completed. COMPLETE � The job is complete. FAILED � The job failed.An additional error field will describe the failure.
        /// </returns>
        Task<SaveUrlJob> SaveUrlJobAsync(string jobId, string asTeamMember = null, CancellationToken cancellationToken = default(CancellationToken));
    }
}