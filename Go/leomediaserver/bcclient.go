package main

import (
	"net"
	"os"
	"fmt"
	"time"
)


func main(){
	addr, _ := net.ResolveUDPAddr("udp", ":57890")
	conn, _ := net.ListenUDP("udp", addr)
	for {
		time.Sleep(time.Second * 1)

		var buf [5120] byte

		var n, _, err = conn.ReadFromUDP(buf[0:])
		checkError(err)

		fmt.Println(string(buf[0:n]))
	}
}

func checkError(err error) {
	if err != nil {
		fmt.Fprintf(os.Stderr, "Fatal error ", err)
		//os.Exit(1)
	}
}
