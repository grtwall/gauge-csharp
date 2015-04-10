﻿// Copyright 2015 ThoughtWorks, Inc.

// This file is part of Gauge-CSharp.

// Gauge-CSharp is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.

// Gauge-Ruby is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.

// You should have received a copy of the GNU General Public License
// along with Gauge-CSharp.  If not, see <http://www.gnu.org/licenses/>.

using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Gauge.CSharp.Runner.Communication
{
    public class TcpClientWrapper : ITcpClientWrapper
    {
        readonly TcpClient _tcpClient = new TcpClient();
        public TcpClientWrapper(int port)
        {
            try
            {
                _tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, port));
            }
            catch (Exception e)
            {
                throw new Exception("Could not connect", e);
            }
        }

        public bool Connected
        {
            get { return _tcpClient.Connected; }
        }

        public Stream GetStream()
        {
            return _tcpClient.GetStream();
        }

        public void Close()
        {
            _tcpClient.Close();
        }
    }
}