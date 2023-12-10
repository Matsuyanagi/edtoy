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
require 'pp'

#-----------------------------------------------------------------------------
#	
#-----------------------------------------------------------------------------
# 二乗テーブル
$square_table = {}
# 逆数テーブル
$recipro_table = {}
# 平方根テーブル
$sqrt_table = {}
# 非平方剰余数
$no_sqrt_table = []


def reg(n, prime)
	n%prime
end

# 平方根があれば±で配列を返す [2,-2%prime]
def sqrt(n,prime)
	return 0 if n == 0
	$sqrt_table[n % prime]
end

def recipro( n, prime )
	$recipro_table[ n % prime ]
end


def init(prime)
	(1...prime).each do |a|
		# 平方テーブルを作る
		$square_table[a] = (a * a) % prime
		# 逆数テーブルを作る
		$recipro_table[a] = a.to_bn.mod_exp(prime-2,prime).to_i
	end
	# 平方テーブルの逆が平方根テーブル
	$square_table.each do |k,v|
		if $sqrt_table[v].nil?
			$sqrt_table[v] = [ k ]
		else
			$sqrt_table[v] << k
		end
	end
	
	$no_sqrt_table = (1...prime).to_a - $square_table.values.flatten
	

end


def main
	# prime = 43
	# d = 2
	prime = 47
	d = 5
	points = []
	
	init(prime)
	# x = 1 .. prime-1
	# y2 から力技で曲線上の (1,y),(2,y),(3,y),... を探す
	(0...prime).each do |x|
		y2 = ( (1-x*x)%prime * recipro( (1-d*x*x)%prime, prime ) ) % prime
		y_arr = sqrt( y2, prime )
		next if y_arr.nil?
		
		points << [ x, y_arr[0] ]
		unless y_arr[1].nil?
			# ダブっていたら 同じ y で複数回は登録しない
			points << [ x, y_arr[1] ]
		end
	end
	points.uniq!

	puts( "平方テーブル : #{$square_table.pretty_inspect}" )
	puts( "平方根テーブル : #{$sqrt_table.pretty_inspect}" )
	puts( "逆数テーブル : #{$recipro_table.pretty_inspect}" )
	puts( "曲線上の点 : #{points.pretty_inspect}" )
	puts( "非平方剰余数(d候補) : #{$no_sqrt_table.pretty_inspect}" )
	
	
	
	

end

main