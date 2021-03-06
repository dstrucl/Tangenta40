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
using System.Threading;
using System.Threading.Tasks;
using DropboxRestAPI.Models.Business;
using DropboxRestAPI.RequestsGenerators.Business;

namespace DropboxRestAPI.Services.Business
{
    public class Groups : IGroups
    {
        private readonly IRequestExecuter _requestExecuter;
        private readonly IGroupsRequestGenerator _requestGenerator;

        public Groups(IRequestExecuter requestExecuter, IGroupsRequestGenerator requestGenerator)
        {
            _requestGenerator = requestGenerator;
            _requestExecuter = requestExecuter;
        }


        public async Task<GroupsInfo> GetInfoAsync(IEnumerable<string> group_ids, CancellationToken cancellationToken = new CancellationToken())
        {
            return await _requestExecuter.Execute<GroupsInfo>(() => _requestGenerator.GetInfoAsync(group_ids), cancellationToken: cancellationToken).ConfigureAwait(false);
        }

        public async Task<GroupsInfo> ListAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            return await _requestExecuter.Execute<GroupsInfo>(() => _requestGenerator.ListAsync(), cancellationToken: cancellationToken).ConfigureAwait(false);
        }
    }
}