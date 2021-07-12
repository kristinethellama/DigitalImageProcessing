#define MyServerFunctions __declspec(dllexport)
#pragma warning(suppress : 4996)

#include <winsock2.h>
#include <windows.h>
#include <ws2tcpip.h>
#include <stdlib.h>
#include <string>
#include <sstream>
#include <stdio.h>
#include <iostream>
#include <fstream>
#include <cstring>
#include <direct.h>
#include <filesystem>

using namespace std;

// server
// Need to link with Ws2_32.lib
#pragma comment (lib, "Ws2_32.lib")
// #pragma comment (lib, "Mswsock.lib")

// client
// Need to link with Ws2_32.lib, Mswsock.lib, and Advapi32.lib
#pragma comment (lib, "Ws2_32.lib")
#pragma comment (lib, "Mswsock.lib")
#pragma comment (lib, "AdvApi32.lib")

#define DEFAULT_BUFLEN 512
#define DEFAULT_PORT "27015"

extern "C" {
    SOCKET ConnectSocket;
    SOCKET ClientSocket;
    SOCKET ListenSocket;

	MyServerFunctions int __cdecl startServer(void) {
        WSADATA wsaData;
        int iResult;

        ListenSocket = INVALID_SOCKET;
        ClientSocket = INVALID_SOCKET;

        struct addrinfo* result = NULL;
        struct addrinfo hints;

        int iSendResult;
        char recvbuf[DEFAULT_BUFLEN];
        int recvbuflen = DEFAULT_BUFLEN;

        // Initialize Winsock
        iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
        if (iResult != 0) {
            printf("WSAStartup failed with error: %d\n", iResult);
            return 1;
        }

        ZeroMemory(&hints, sizeof(hints));
        hints.ai_family = AF_INET;
        hints.ai_socktype = SOCK_STREAM;
        hints.ai_protocol = IPPROTO_TCP;
        hints.ai_flags = AI_PASSIVE;

        // Resolve the server address and port
        iResult = getaddrinfo(NULL, DEFAULT_PORT, &hints, &result);
        if (iResult != 0) {
            printf("getaddrinfo failed with error: %d\n", iResult);
            WSACleanup();
            return 1;
        }

        // Create a SOCKET for connecting to server
        ListenSocket = socket(result->ai_family, result->ai_socktype, result->ai_protocol);
        if (ListenSocket == INVALID_SOCKET) {
            printf("socket failed with error: %ld\n", WSAGetLastError());
            freeaddrinfo(result);
            WSACleanup();
            return 1;
        }

        // Setup the TCP listening socket
        iResult = bind(ListenSocket, result->ai_addr, (int)result->ai_addrlen);
        if (iResult == SOCKET_ERROR) {
            printf("bind failed with error: %d\n", WSAGetLastError());
            freeaddrinfo(result);
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        freeaddrinfo(result);

        iResult = listen(ListenSocket, SOMAXCONN);
        if (iResult == SOCKET_ERROR) {
            printf("listen failed with error: %d\n", WSAGetLastError());
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        // Accept a client socket
        ClientSocket = accept(ListenSocket, NULL, NULL);
        if (ClientSocket == INVALID_SOCKET) {
            printf("accept failed with error: %d\n", WSAGetLastError());
            closesocket(ListenSocket);
            WSACleanup();
            return 1;
        }

        // No longer need server socket
        closesocket(ListenSocket);

        /*
        // Receive until the peer shuts down the connection
        do {

            iResult = recv(ClientSocket, recvbuf, recvbuflen, 0);
            if (iResult > 0) {
                printf("Bytes received: %d\n", iResult);

                // Echo the buffer back to the sender
                std::string temp = "bitch";
                //iSendResult = send(ClientSocket, temp.c_str(), bufferSize, 0);

                iSendResult = send(ClientSocket, temp.c_str(), iResult, 0);
                //iSendResult = send(ListenSocket, temp, bufferSize, 0);
                if (iSendResult == SOCKET_ERROR) {
                    printf("send failed with error: %d\n", WSAGetLastError());
                    closesocket(ClientSocket);
                    WSACleanup();
                    return 1;
                }
                printf("Bytes sent: %d\n", iSendResult);
            }
            else if (iResult == 0)
                printf("Connection closing...\n");
            else {
                printf("recv failed with error: %d\n", WSAGetLastError());
                closesocket(ClientSocket);
                WSACleanup();
                return 1;
            }

        } while (iResult > 0);
        */
        return 0;
	}

    MyServerFunctions int closeServer(void) { 
        // shutdown the connection since we're done
        int iResult = 0;
        iResult = shutdown(ClientSocket, SD_SEND);
        if (iResult == SOCKET_ERROR) {
            printf("shutdown failed with error: %d\n", WSAGetLastError());
            closesocket(ClientSocket);
            WSACleanup();
            return 1;
        }

        // cleanup
        closesocket(ClientSocket);
        WSACleanup();
        return 0;
    }

    MyServerFunctions int sendall(SOCKET s, const char* buf, int* len)
    {
        int total = 0;        // how many bytes we've sent
        int bytesleft = *len; // how many we have left to send
        int n;

        while (total < *len) {
            n = send(s, buf + total, bytesleft, 0);
            if (n == -1) { break; }
            total += n;
            bytesleft -= n;
        }

        *len = total; // return number actually sent here

        return n == -1 ? -1 : 0; // return -1 on failure, 0 on success
    }

    MyServerFunctions void sendingStuff(void) {
        
        // code to get file path
        FILE* fd;
        int iResult = 0;
        string fileLoc = "c:\\temp\\record.avi";

        fopen_s(&fd, fileLoc.c_str(), "rb");

        int bytes_read;
        char buffer[4096] = {};

        //do {
            // 
        //} while (iResult > 0);
        //iResult = recv(ClientSocket, buffer, 4096, 0);

        while (!feof(fd)) {
            //iResult = recv(ClientSocket, buffer, 4096, 0);

            if ((bytes_read = fread(&buffer, 1, 4096, fd)) > 0)
                send(ClientSocket, buffer, bytes_read, 0);
            else
                break;
        }
        fclose(fd);

        return;
    }

    MyServerFunctions int stopClient(void) {
        // shutdown the connection since we're done
        int iResult = 0;
        iResult = shutdown(ConnectSocket, SD_SEND);
        if (iResult == SOCKET_ERROR) {
            printf("shutdown failed with error: %d\n", WSAGetLastError());
            closesocket(ConnectSocket);
            WSACleanup();
            return 1;
        }

        // cleanup
        closesocket(ConnectSocket);
        WSACleanup();
        return 0;
    }

    MyServerFunctions int __cdecl startClient(void) {
        WSADATA wsaData;
        ConnectSocket = INVALID_SOCKET;
        struct addrinfo* result = NULL,
            * ptr = NULL,
            hints;
        const char* sendbuf = "this is a test";
        char recvbuf[DEFAULT_BUFLEN];
        int iResult;
        int recvbuflen = DEFAULT_BUFLEN;
        const char* ipAddr = "localhost";

        // Initialize Winsock
        iResult = WSAStartup(MAKEWORD(2, 2), &wsaData);
        if (iResult != 0) {
            printf("WSAStartup failed with error: %d\n", iResult);
            return 1;
        }

        ZeroMemory(&hints, sizeof(hints));
        hints.ai_family = AF_UNSPEC;
        hints.ai_socktype = SOCK_STREAM;
        hints.ai_protocol = IPPROTO_TCP;

        // Resolve the server address and port
        iResult = getaddrinfo(ipAddr, DEFAULT_PORT, &hints, &result);
        if (iResult != 0) {
            printf("getaddrinfo failed with error: %d\n", iResult);
            WSACleanup();
            return 1;
        }

        // Attempt to connect to an address until one succeeds
        for (ptr = result; ptr != NULL; ptr = ptr->ai_next) {

            // Create a SOCKET for connecting to server
            ConnectSocket = socket(ptr->ai_family, ptr->ai_socktype,
                ptr->ai_protocol);
            if (ConnectSocket == INVALID_SOCKET) {
                printf("socket failed with error: %ld\n", WSAGetLastError());
                WSACleanup();
                return 1;
            }

            // Connect to server.
            iResult = connect(ConnectSocket, ptr->ai_addr, (int)ptr->ai_addrlen);
            if (iResult == SOCKET_ERROR) {
                closesocket(ConnectSocket);
                ConnectSocket = INVALID_SOCKET;
                continue;
            }
            break;
        }

        freeaddrinfo(result);

        if (ConnectSocket == INVALID_SOCKET) {
            printf("Unable to connect to server!\n");
            WSACleanup();
            return 1;
        }

        

        
        // Send an initial buffer
        iResult = send(ConnectSocket, sendbuf, (int)strlen(sendbuf), 0);
        if (iResult == SOCKET_ERROR) {
            printf("send failed with error: %d\n", WSAGetLastError());
            closesocket(ConnectSocket);
            WSACleanup();
            return 1;
        }

        /*
        //System.Diagnostics.Debug.WriteLine(sendbuf);
        printf("Bytes Sent: %ld\n", iResult);

        // shutdown the connection since no more data will be sent
        iResult = shutdown(ConnectSocket, SD_SEND);
        if (iResult == SOCKET_ERROR) {
            printf("shutdown failed with error: %d\n", WSAGetLastError());
            closesocket(ConnectSocket);
            WSACleanup();
            return 1;
        }
        */

        //OutputDebugStringA(a.c_str());
        //printf("%c\n", recvbuf[0]);

        // Receive until the peer closes the connection
       /* do {

            iResult = recv(ConnectSocket, recvbuf, recvbuflen, 0);
            if (iResult > 0)
                printf("Bytes received: %d\n", iResult);
            else if (iResult == 0)
                printf("Connection closed\n");
            else
                printf("recv failed with error: %d\n", WSAGetLastError());

        } while (iResult > 0);
        */

        // cleanup
        //closesocket(ConnectSocket);
        //WSACleanup();

        return 0;
    }
}

extern "C"  MyServerFunctions void testString2(void)
{
    char buffer[4096] = {};
    size_t datasize;
    FILE* fd;

    string out = "c:\\temp\\result.avi";

    fopen_s(&fd, out.c_str(), "wb");

    while (true)
    {
        datasize = recv(ConnectSocket, buffer, sizeof(buffer), 0);

        if (datasize == 0)
        {
            break;
        }
        fwrite(&buffer, 1, datasize, fd);
    }
    fclose(fd);

    return;
}