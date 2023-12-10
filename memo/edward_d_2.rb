#!/usr/bin/env ruby
# -*- coding: utf-8 -*-
#-----------------------------------------------------------------------------
#	エドワーズ曲線上の点を求める
#		d は prime 上の非平方剰余数。
#		prime = 4n+3 なら、a^((p-1)/2) == 1 なら平方剰余。
#	
#	
#	2023-12-11
#-----------------------------------------------------------------------------

#-----------------------------------------------------------------------------
#	
#-----------------------------------------------------------------------------
require 'openssl'

#-----------------------------------------------------------------------------
#	
#-----------------------------------------------------------------------------
# 二乗テーブル
$square_table = {}
# 逆数テーブル
$recipro_table = {}
# 平方根テーブル
$sqrt_table = {}

def reg(n, prime)
	n%prime
end

def sqrt(n,prime)
	return 0 if n == 0
	$sqrt_table[n % prime]
end

def recipro( n, prime )
	$recipro_table[ n % prime ]
end


def init(prime)
	(1...prime).each do |a|
		$square_table[a] = (a * a) % prime
		$recipro_table[a] = a.to_bn.mod_exp(prime-2,prime).to_i
	end
	$square_table.each do |k,v|
		$sqrt_table[v] = k
	end

end


def main
	# prime = 43
	prime = 47
	d = 5
	points = []
	
	
	init(prime)
	# x = 1 .. prime-1
	(1...prime).each do |x|
		pp x
		y2 = ( (1-x*x)%prime * recipro( (1-d*x*x)%prime, prime ) ) % prime
		y = sqrt( y2, prime )
		next if y.nil?
		if !y
			puts "x = #{x}, √y2 = nil : #{y2}"
		end
		
		points << [ x, y ]
		points << [ x, (-y)%prime ]
	end
	points.uniq!
	

	pp $square_table
	pp $sqrt_table
	pp $recipro_table
	pp points

	
	
	
	

end

main