package main

import (
	"net"
	"fmt"
	"time"
)


func main(){

	conn, _:= net.Dial("udp", "255.255.255.255:57890")

	defer conn.Close()

	var localaddr = conn.LocalAddr().String()
	host, _, _ := net.SplitHostPort(localaddr)

	fmt.Println("Broadcast for this " + host)
	for {
		time.Sleep(time.Second * 10)

		_, _ = conn.Write([]byte(host))
	}
}
